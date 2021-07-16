namespace ARS_ProjectSystem.Infrastructure
{
    using ARS_ProjectSystem.Data;
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
        }
        private static void SeedProposals(ProjectSystemDbContext data)
        {
            if (data.Proposals.Any())
            {
                return;
            }
        }
    }
}

