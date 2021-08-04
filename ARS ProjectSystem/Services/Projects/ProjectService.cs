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
            ProgrammId = p.Programm.Id,
            ProjectPhoto = p.ProjectPhoto,
            Status = p.Status,
            StartDate = p.StartDate,
            EndDate = p.EndDate,
            ProjectRate = p.ProjectRate,
            CustomerRegistrationNumber = p.CustomerRegistrationNumber
            })
                .ToList();

        public IEnumerable<ProjectProposalsServiceModel> GetProjectProposals()
        => this.data
                .Proposals
                .Select(c => new ProjectProposalsServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

        public IEnumerable<ProjectCustomersServiceModel> GetProjectCustomers()
        =>this.data
                .Customers
                .Select(c => new ProjectCustomersServiceModel
                {
                    RegistrationNumber=c.RegistrationNumber,
                    Name = c.Name
                })
            .ToList();

    public IEnumerable<ProjectProgrammsServiceModel> GetProjectProgramms()
        => this.data
                .Programms
                .Select(c => new ProjectProgrammsServiceModel
                {
                    Id = c.Id,
                    Name = c.ProgrammName
                })
                .ToList();

        public ProjectServiceModel Details(int id)
        => this.data
            .Projects
            .Where(p => p.Id == id)
            .Select(p => new ProjectServiceModel
            {
                Id = p.Id,
                Name = p.Name,
                ProgrammId = p.Programm.Id,
                ProjectPhoto = p.ProjectPhoto,
                Status = p.Status,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                ProjectRate = p.ProjectRate,
                CustomerRegistrationNumber = p.Customer.Name
            }).FirstOrDefault();

        public bool ProposalExists(int proposalId)
            => this.data
            .Proposals.Any(c => c.Id == proposalId);

        public int Create(int id, string name, int programmId, string projectPhoto, string status, string startDate, string endDate, double projectRate, string customerRegistrationNumber)
        {
            var projectData = new Project
            {
                Id = id,
                Name = name,
                ProgrammId = programmId,
                ProjectPhoto = projectPhoto,
                Status = status,
                StartDate = startDate,
                EndDate = endDate,
                ProjectRate = projectRate,
                CustomerRegistrationNumber = customerRegistrationNumber
            };
            this.data.Projects.Add(projectData);
            this.data.SaveChanges();
            return projectData.Id;
        }
        public bool Edit(int id, string name, int programmId, string projectPhoto, string status, string startDate, string endDate, double projectRate, string customerRegistrationNumber)
        {
            var projectData = this.data.Projects.Find(id);
            //if you can edit the project
            //if()
            //{
            //    return false;
            //}

            projectData.Name = name;
            projectData.ProgrammId = programmId;
            projectData.ProjectPhoto = projectPhoto;
            projectData.Status = status;
            projectData.StartDate = startDate;
            projectData.EndDate = endDate;
            projectData.ProjectRate = projectRate;

            this.data.SaveChanges();
            return true;
        }

        
        //public bool IsByUser(int projectId, int userId)
        //=> this.data
        //        .Projects
        //        .Any(c => c.Id == projectId && c.Id == userId);

    }
}
