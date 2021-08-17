namespace ARS_ProjectSystem.Controllers.API
{
    using ARS_ProjectSystem.Models.Api.Projects;
    using ARS_ProjectSystem.Services.Projects;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/projects")]
    public class ProjectsApiController : ControllerBase
    {
        private readonly IProjectService projects;

        public ProjectsApiController(IProjectService projects)
        {
            this.projects = projects;
        }

        [HttpGet]
        public ActionResult<ProjectQueryServiceModel> All([FromQuery] AllProjectsApiRequestModel query)
            => this.projects.All(query.Programm,query.SearchTerm,
                query.Sorting,query.CurrentPage,query.ProjectsPerPage);
    }
}
