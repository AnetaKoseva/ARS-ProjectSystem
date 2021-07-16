namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Projects;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class ProjectsController:Controller
    {
        private readonly ProjectSystemDbContext data;
        public ProjectsController(ProjectSystemDbContext data) 
            => this.data = data;
        //public IActionResult Add() => View();
        public IActionResult Add() => View(new AddProjectFormModel
        {
            Programms = this.GetProjectProgramms(),
            Proposals = this.GetProjectProposals()
        });
        public IActionResult All(string searchTerm,ProjectSorting sorting)
        {
            var projectQuery = this.data.Projects.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                projectQuery = projectQuery.Where(c =>
                    c.Name.ToLower().Contains(searchTerm.ToLower())
                    || c.Programm.ProgrammName.ToLower().Contains(searchTerm.ToLower()));
            }

            //projectQuery = sorting switch
            //{
            //    ProjectSorting.Programm=>projectQuery.OrderByDescending(p=>p.Programm.ProgrammName)
            //};
            var projects = projectQuery
                .OrderBy(p => p.Name)
                .Select(p => new ProjectsListingViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ProgrammName=p.Programm.ProgrammName,
                    ProposalName=p.Proposal.Name,
                    ProjectPhoto=p.ProjectPhoto,
                    Status=p.Status,
                    StartDate=p.StartDate,
                    EndDate=p.EndDate,
                    ProjectRate=p.ProjectRate
                })
                .ToList();
            return View(new AllProjectsQueryModel
            {
                Projects = projects,
                SearchTerm = searchTerm
            });
        }
        [HttpPost]
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
    }
}
