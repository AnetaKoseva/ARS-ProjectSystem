namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Infrastructure;
    using ARS_ProjectSystem.Models.Projects;
    using ARS_ProjectSystem.Services.Projects;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;
    public class ProjectsController : Controller
    {
        private readonly IProjectService projects;
        private readonly IMapper mapper;
        public ProjectsController( IProjectService projects, IMapper mapper)
        {
            this.mapper = mapper;
            this.projects = projects;
        }

        [Authorize]
        public IActionResult Add()
        {
            return View(new ProjectFormModel
            {
                Programms = this.projects.GetProjectProgramms(),
                Proposals = this.projects.GetProjectProposals(),
                Customers = this.projects.GetProjectCustomers()
            });
        }
        public IActionResult All([FromQuery] AllProjectsQueryModel query)
        {
            var queryResult = this.projects.All(
                query.Programm,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllProjectsQueryModel.ProjectsPerPage);

            var projectProgramms = this.projects.AllProjectProgramms();

            query.TotalProjects = queryResult.TotalProjects;
            query.Projects = queryResult.Projects;
            query.Programms = projectProgramms;

            return View(query);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(ProjectFormModel project)
        {
            //is it true.Check
            if (!this.projects.ProposalExists(project.ProposalId.GetValueOrDefault()))
            {
                this.ModelState.AddModelError(nameof(project.ProposalId), "Proposal does not exist.");
            }

            if (!ModelState.IsValid)
            {
                project.Programms = this.projects.GetProjectProgramms();
                project.Proposals = this.projects.GetProjectProposals();
                project.Customers = this.projects.GetProjectCustomers();
                
                return View();
            }
            
            this.projects.Create(project.Id,
                project.Name,
                project.ProgrammId,
                project.ProjectPhoto,
                project.Status,
                project.StartDate,
                project.EndDate,
                project.ProposalId.GetValueOrDefault(),
                project.ProjectRate,
                project.CustomerRegistrationNumber);

            TempData[GlobalMessageKey] = $"You project {project.Name} is added succesfully!";
            
            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Details(int projectId)
        {
            var project = this.projects.Details(projectId);
            return this.View(project);
        }
        
        [Authorize]
        public IActionResult Edit(int id)
        {
            var project = this.projects.Details(id);

            //automapping registered in MappingProfile
            var projectForm = this.mapper.Map<ProjectFormModel>(project);
            projectForm.Programms = this.projects.GetProjectProgramms();
            projectForm.Proposals = this.projects.GetProjectProposals();
            projectForm.Customers = this.projects.GetProjectCustomers();

            return View(projectForm);

            //return View(new ProjectFormModel
            //{
            //    Id = project.Id,
            //    Name = project.Name,
            //    ProgrammId = project.ProgrammId,
            //    ProjectPhoto = project.ProjectPhoto,
            //    Status = project.Status,
            //    StartDate = project.StartDate,
            //    EndDate = project.EndDate,
            //    ProjectRate = project.ProjectRate,
            //    CustomerRegistrationNumber = project.CustomerRegistrationNumber,
            //    Programms = this.projects.GetProjectProgramms(),
            //    Proposals = this.projects.GetProjectProposals(),
            //    Customers = this.projects.GetProjectCustomers()
            //});
        }
        [Authorize(Roles ="Administrator")]
        [HttpPost]
        public IActionResult Edit(int id,ProjectFormModel project)
        {
           var projectIsEdited=this.projects.Edit(
                project.Id,
                project.Name,
                project.ProgrammId,
                project.ProjectPhoto,
                project.Status,
                project.StartDate,
                project.EndDate,
                project.ProjectRate,
                project.CustomerRegistrationNumber);

            if(!projectIsEdited||!User.IsAdmin())
            {
                return BadRequest();
            }

            TempData[GlobalMessageKey] = $"You project {project.Name} is edited!";
            
            return RedirectToAction(nameof(All));
        }
    }
}
