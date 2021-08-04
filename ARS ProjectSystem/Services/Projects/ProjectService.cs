namespace ARS_ProjectSystem.Services.Projects
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProjectService : IProjectService
    {
        private readonly ProjectSystemDbContext data;
        public ProjectService(ProjectSystemDbContext data)
            => this.data = data;
        
        public ProjectQueryServiceModel All(string programm,
            string searchTerm,
            ProjectSorting sorting,
            int currentPage,
            int projectsPerPage)
        {
            var projectQuery = this.data.Projects.AsQueryable();
            if (!string.IsNullOrWhiteSpace(programm))
            {
                projectQuery = projectQuery.Where(p => p.Programm.ProgrammName == programm);
            }
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                projectQuery = projectQuery.Where(c =>
                    c.Name.ToLower().Contains(searchTerm.ToLower())
                    || c.Programm.ProgrammName.ToLower().Contains(searchTerm.ToLower()));
            }

            projectQuery = sorting switch
            {
                ProjectSorting.Programm => projectQuery.OrderByDescending(p => p.Programm.ProgrammName),
                ProjectSorting.Status => projectQuery.OrderByDescending(p => p.Status).ThenBy(p=>p.Programm.ProgrammName),
                _ => projectQuery.OrderBy(p => p.Name)
            };
            var totalProjects = projectQuery.Count();

            var projects = GetProjects(projectQuery
                .Skip((currentPage - 1) * projectsPerPage)
                .Take(projectsPerPage));
                
            return new ProjectQueryServiceModel
            {
                CurrentPage = currentPage,
                TotalProjects = totalProjects,
                Projects = projects,
                ProjectsPerPage = projectsPerPage
            };
        }
        public IEnumerable<ProjectServiceModel> ByUser(string userId)
        {
            //var customer = this.data.Customers.Where(c => c.ProjectSystemUser.UserId == userId);
            return GetProjects(this.data.Projects.Where(p => p.Customer.Users.Any(c=>c.Id==userId)));
            
        }
        public IEnumerable<string> AllProjectProgramms()
            => this.data
                .Projects
                .Select(p => p.Programm.ProgrammName)
                .Distinct()
                .OrderBy(p => p)
                .ToList();

        private static IEnumerable<ProjectServiceModel> GetProjects(IQueryable<Project> projectsQuery)
            =>projectsQuery.Select(p => new ProjectServiceModel
        {
            Id = p.Id,
            Name = p.Name,
            ProgrammName = p.Programm.ProgrammName,

            ProjectPhoto = p.ProjectPhoto,
            Status = p.Status,
            StartDate = p.StartDate,
            EndDate = p.EndDate,
            ProjectRate = p.ProjectRate,
            CustomerName = p.Customer.Name
        })
                .ToList();
    }
}
