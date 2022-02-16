namespace ARS_ProjectSystem.Services.Projects
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models;
    using ARS_ProjectSystem.Models.Projects;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;

    public class ProjectService : IProjectService
    {
        private readonly ProjectSystemDbContext data;
        private readonly IMapper mapper;
        public ProjectService(ProjectSystemDbContext data,
            IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

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
                .Proposals.Where(p=>p.ProjectId!=null ||p.ProjectId!=0)
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
            .ProjectTo<ProjectServiceModel>(this.mapper.ConfigurationProvider)
            .FirstOrDefault();

        public bool ProposalExists(int proposalId)
            => this.data
            .Proposals.Any(c => c.Id == proposalId);

        public int Create(ProjectFormModel project)
        {
            var projectData = new Project
            {
                Id = project.Id,
                Name = project.Name,
                ProgrammId = project.ProgrammId,
                ProjectPhoto = project.ProjectPhoto,
                Status = project.Status,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                ProjectRate = project.ProjectRate,
                ProposalId= project.ProposalId,
                CustomerRegistrationNumber = project.CustomerRegistrationNumber
            };

            this.data.Projects.Add(projectData);
            this.data.SaveChanges();

            return projectData.Id;
        }

        public bool Edit(ProjectFormModel project)
        {
            var projectData = this.data.Projects.Find(project.Id);

            projectData.Name = project.Name;
            projectData.ProgrammId = project.ProgrammId;
            projectData.ProjectPhoto = project.ProjectPhoto;
            projectData.Status = project.Status;
            projectData.StartDate = project.StartDate;
            projectData.EndDate = project.EndDate;
            projectData.ProjectRate = project.ProjectRate;

            this.data.SaveChanges();

            return true;
        }

        public IEnumerable<ProjectTotalServiceModel> Total()
            => this.data
                .Projects
                .OrderByDescending(p => p.Id)
                .ProjectTo<ProjectTotalServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

        public IEnumerable<ProjectProposal> AllProjects()
        {
            var allProjects = this.data.Projects.Select(p=>new ProjectProposal 
            { 
             Id=p.Id,
              Name=p.Name,
               ProjectPhoto=p.ProjectPhoto
            }).ToList();
            return allProjects;
        }
    }
}
