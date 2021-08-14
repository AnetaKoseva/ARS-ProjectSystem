namespace ARS_ProjectSystem.Test.Routing
{
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Models.Projects;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ProjectsControllerTest
    {
        [Fact]
        public void GetAddRouteShouldBeMapperd()
            => MyRouting
            .Configuration()
            .ShouldMap("/Projects/Add")
            .To<ProjectsController>(c => c.Add());
        [Fact]
        public void PostAddRouteShouldBeMapperd()
            => MyRouting
            .Configuration()
            .ShouldMap(request=>request.WithPath("/Projects/Add")
            .WithMethod(HttpMethod.Post))
            .To<ProjectsController>(c => c.Add(With.Any<ProjectFormModel>()));
        
    }
}
