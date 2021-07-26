namespace ARS_ProjectSystem.Controllers.API
{
    using ARS_ProjectSystem.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections;
    using System.Linq;

    [ApiController]
    [Route("api/projects")]
    public class ProjectsApi : ControllerBase
    {
        private readonly ProjectSystemDbContext data;
        public ProjectsApi(ProjectSystemDbContext data)
            => this.data = data;
        [HttpGet]
        public IEnumerable GetProjects()
        {
            return this.data.Projects.ToList();
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
