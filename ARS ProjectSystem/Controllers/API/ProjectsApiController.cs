namespace ARS_ProjectSystem.Controllers.API
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Models;
    using ARS_ProjectSystem.Models.Api.Projects;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections;
    using System.Linq;

    [ApiController]
    [Route("api/projects")]
    public class ProjectsApiController : ControllerBase
    {
        private readonly ProjectSystemDbContext data;
        public ProjectsApiController(ProjectSystemDbContext data)
            => this.data = data;
        [HttpGet]
        public ActionResult<AllProjectsApiResponseModel> All([FromQuery] AllProjectsApiRequestModel query)
        {
            var projectQuery = this.data.Projects.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Programm))
            {
                projectQuery = projectQuery.Where(p => p.Programm.ProgrammName == query.Programm);
            }
            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                projectQuery = projectQuery.Where(c =>
                    c.Name.ToLower().Contains(query.SearchTerm.ToLower())
                    || c.Programm.ProgrammName.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            projectQuery = query.Sorting switch
            {
                ProjectSorting.Programm => projectQuery.OrderByDescending(p => p.Programm.ProgrammName),
                ProjectSorting.Status => projectQuery.OrderByDescending(p => p.Status),
                _ => projectQuery.OrderBy(p => p.Name)
            };
            var totalProjects = projectQuery.Count();

            var projects = projectQuery
                .Skip((query.CurrentPage - 1) * query.ProjectsPerPage)
                .Take(query.ProjectsPerPage)
                .Select(p => new ProjectResponseModel
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
            var projectProgramms = this.data
                .Projects
                .Select(p => p.Programm.ProgrammName)
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            return new AllProjectsApiResponseModel
            {
                TotalProjects = totalProjects,
                CurrentPage = query.CurrentPage,
                ProjectsPerPage=query.ProjectsPerPage,
                Projects = projects
            };
        }
            [HttpGet]
        [Route("{id}")]
        public IActionResult GetDetails(int id)
        {
            var project= this.data
                .Projects
                .Find(id);
            if(project==null)
            {
                return NotFound();
            }
            return Ok(project);
        }
    }
}
