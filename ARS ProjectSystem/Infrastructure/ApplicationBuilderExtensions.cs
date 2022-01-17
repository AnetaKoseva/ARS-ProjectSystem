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
    using static ARS_ProjectSystem.Areas.User.UserConstants;
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
            SeedNormalUser(services);

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

            data.Programms.Add(new Programm
            {
                ProgrammName="Horizon2020",
                Description="Horizon 2020 is the financial instrument implementing the Innovation Union, a Europe 2020 flagship initiative aimed at securing Europe's global competitiveness.",
                Url="https://ec.europa.eu/programmes/horizon2020/en/home"
            });
        }
        private static void SeedProposals(IServiceProvider services)
        {
            var data = services.GetRequiredService<ProjectSystemDbContext>();

            if (data.Proposals.Any())
            {
                return;
            }

            data.Proposals.AddRange(new Proposal
            {
                Name="SysAgria",
                Budget=2000000,
                CreatedOn= "01012020",
                CustomerRegistrationNumber = "99999999",
                UrlPhoto= "https://www.sysagria.ro/static/media/left_part.a43a83c2.png"
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

                    const string adminEmail = "admin@ars.com";
                    const string adminPassword = "admin2020";
                   
                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        Number = "203300624"
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
        private static void SeedNormalUser(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                   
                    if (await roleManager.RoleExistsAsync(NormalUserRoleName))
                    {
                        return;
                    }

                    var roleNormalUser = new IdentityRole { Name = NormalUserRoleName };

                    await roleManager.CreateAsync(roleNormalUser);

                    const string normalUserEmail = "normalUser@ars.com";
                    const string normalUserPassword = "normalUser2020";

                    var normalUser = new User
                    {
                        Email = normalUserEmail,
                        UserName = normalUserEmail,
                        Number = "203300624"

                    };

                    await userManager.CreateAsync(normalUser, normalUserPassword);

                    await userManager.AddToRoleAsync(normalUser, roleNormalUser.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
