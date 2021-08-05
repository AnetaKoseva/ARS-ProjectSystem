namespace ARS_ProjectSystem.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using static ARS_ProjectSystem.Areas.Admin.AdminConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedProgramms(services);
            SeedProposals(services);
            SeedAdministrator(services);

            return app;
        }
        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ProjectSystemDbContext>();
            data.Database.Migrate();
        }
        private static void SeedProgramms(IServiceProvider services)
        {
            var data = services.GetRequiredService<ProjectSystemDbContext>();
            if (data.Programms.Any())
            {
                return;
            }
            data.Programms.AddRange(new[]
            {
                new Programm{ProgrammName="Horizon2020",Url="https://ec.europa.eu/programmes/horizon2020/en/home" },
                new Programm{ ProgrammName="EIC accelerator",Url="https://eic.ec.europa.eu/eic-funding-opportunities/eic-accelerator_en"}

            });
        }
        private static void SeedProposals(IServiceProvider services)
        {
            var data = services.GetRequiredService<ProjectSystemDbContext>();
            if (data.Proposals.Any())
            {
                return;
            }
            data.Proposals.AddRange(new[]
            {
                new Proposal{Name="AI4Media", },
                new Proposal{Name="SysAgria",}
            });
        }
        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@crs.com";
                    const string adminPassword = "admin2020";

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        FullName = "Admin"
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
