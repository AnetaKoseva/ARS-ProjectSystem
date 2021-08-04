namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Infrastructure;
    using ARS_ProjectSystem.Models.Projects;
    using ARS_ProjectSystem.Services.Projects;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class ProjectsController : Controller
    {
        private readonly IProjectService projects;
        
        public ProjectsController( IProjectService projects)
        {
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
                project.ProjectRate,
                project.CustomerRegistrationNumber);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Details(int projectId)
        {
            //var project = this.data.Projects
            //    .First(t => t.Id == int.Parse(projectId));
            var project = this.projects.Details(projectId);
            return this.View(project);

        }
        public IActionResult Mine()
        {
            var myProjects = this.projects.ByUser(this.User.GetId());
            return View(myProjects);
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var project = this.projects.Details(id);
            //check if you can edit project return UnAuthorized
            return View(new ProjectFormModel
            {
                Id = project.Id,
                Name = project.Name,
                ProgrammId = project.ProgrammId,
                ProjectPhoto = project.ProjectPhoto,
                Status = project.Status,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                ProjectRate = project.ProjectRate,
                CustomerRegistrationNumber = project.CustomerRegistrationNumber,
                Programms = this.projects.GetProjectProgramms(),
                Proposals = this.projects.GetProjectProposals(),
                Customers = this.projects.GetProjectCustomers()
            });
        }
        [Authorize]
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
            if(!projectIsEdited)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(All));
        }
    }
}
