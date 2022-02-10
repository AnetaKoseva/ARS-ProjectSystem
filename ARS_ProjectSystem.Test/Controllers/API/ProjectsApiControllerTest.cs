namespace ARS_ProjectSystem.Test.Controllers.API
{
    using ARS_ProjectSystem.Controllers.API;
    using ARS_ProjectSystem.Models.Api.Projects;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ProjectsApiControllerTest
    {
        [Fact]
        public void AllProjectsShoudReturnObject()
            => MyController<ProjectsApiController>
           .Instance()
           .Calling(c => c.All(new AllProjectsApiRequestModel { SearchTerm = "aneta" }))
           .ShouldReturn()
           .Object();
    }
}
