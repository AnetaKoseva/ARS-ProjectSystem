namespace ARS_ProjectSystem.Test.Areas.Admin.Controllers
{
    using ARS_ProjectSystem.Areas.Admin.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ProjectsControllerTest
    {
        [Fact]
        public void ControllerTestAdd()
            => MyController<ProjectsController>
            .Calling(c => c.Index())
            .ShouldReturn()
            .View();
    }
}
