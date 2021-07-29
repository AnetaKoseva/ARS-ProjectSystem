namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Projects;
    using ARS_ProjectSystem.Services.Projects;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class ProjectsController:Controller
    {
        private readonly IProjectService projects;
        private readonly ProjectSystemDbContext data;
        public ProjectsController(ProjectSystemDbContext data, IProjectService projects)
        {
            this.data = data;
            this.projects = projects;
        }
        //public IActionResult Add() => View();
        [Authorize]
        public IActionResult Add() => View(new AddProjectFormModel 
        {
            Programms = this.GetProjectProgramms(),
            Proposals = this.GetProjectProposals()
        });
        public IActionResult All([FromQuery]AllProjectsQueryModel query)
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
            query.Programms =projectProgramms;

            return View(query);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(AddProjectFormModel project)
        {
            if (!this.data.Proposals.Any(c => c.Id == project.ProposalId))
            {
                this.ModelState.AddModelError(nameof(project.ProposalId), "Proposal does not exist.");
            }
            if (!ModelState.IsValid)
            {
                project.Programms = this.GetProjectProgramms();
                project.Proposals = this.GetProjectProposals();
                return View();
            }
            var projectData = new Project
            {
                Id=project.Id,
                Name = project.Name,
                ProgrammId=project.ProposalId,
                ProposalId=project.ProposalId,
                ProjectPhoto=project.ProjectPhoto,
                Status=project.Status,
                StartDate=project.StartDate,
                EndDate=project.EndDate,
                ProjectRate=project.ProjectRate,
            };
            this.data.Projects.Add(projectData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }
        private IEnumerable<ProjectProgrammsViewModel> GetProjectProgramms()
            => this.data
                .Programms
                .Select(c => new ProjectProgrammsViewModel
                {
                    Id = c.Id,
                    Name = c.ProgrammName
                })
                .ToList();
        private IEnumerable<ProjectProposalsViewModel> GetProjectProposals()
            => this.data
                .Proposals
                .Select(c => new ProjectProposalsViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
        public IActionResult Details(string projectId)
        {
            var project = this.data.Projects
                .First(t => t.Id == int.Parse(projectId));

            return this.View(project);
        }
        
    }
}
