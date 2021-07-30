namespace ARS_ProjectSystem.Services.Projects
{
    using ARS_ProjectSystem.Data;
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
                ProjectSorting.Status => projectQuery.OrderByDescending(p => p.Status),
                _ => projectQuery.OrderBy(p => p.Name)
            };
            var totalProjects = projectQuery.Count();

            var projects = projectQuery
                .Skip((currentPage - 1) * projectsPerPage)
                .Take(projectsPerPage)
                .Select(p => new ProjectServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ProgrammName = p.Programm.ProgrammName,
                    ProposalName = p.Proposal.Name,
                    ProjectPhoto = p.ProjectPhoto,
                    Status = p.Status,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    ProjectRate = p.ProjectRate
                })
                .ToList();
            
            return new ProjectQueryServiceModel
            {
                CurrentPage = currentPage,
                TotalProjects = totalProjects,
                Projects = projects,
                ProjectsPerPage = projectsPerPage
            };
        }

        public IEnumerable<string> AllProjectProgramms()
            => this.data
                .Projects
                .Select(p => p.Programm.ProgrammName)
                .Distinct()
                .OrderBy(p => p)
                .ToList();
    }
}
