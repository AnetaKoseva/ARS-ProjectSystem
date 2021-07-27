namespace ARS_ProjectSystem.Controllers.API
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Models;
    using ARS_ProjectSystem.Models.Api.Projects;
    using ARS_ProjectSystem.Services.Projects;
    using ARS_ProjectSystem.Services.Statistics;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections;
    using System.Linq;

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
        [HttpGet]
        public ActionResult<ProjectQueryServiceModel> All([FromQuery] AllProjectsApiRequestModel query)
            => this.projects.All(query.Programm,query.SearchTerm,
                query.Sorting,query.CurrentPage,query.ProjectsPerPage);

        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult GetDetails(int id)
        //{
        //    var project= this.data
        //        .Projects
        //        .Find(id);
        //    if(project==null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(project);
        //}
    }
}
