namespace ARS_ProjectSystem.Infrastructure
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<ProjectSystemDbContext>();

            data.Database.Migrate();
            SeedProgramms(data);
            SeedProposals(data);

            return app;
        }
        private static void SeedProgramms(ProjectSystemDbContext data)
        {
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
        private static void SeedProposals(ProjectSystemDbContext data)
        {
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
    }
}

