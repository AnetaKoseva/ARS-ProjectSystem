namespace ARS_ProjectSystem.Test.Controllers
{
    using ARS_ProjectSystem.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Data.ProjectSystem;
    public class ProjectsControllerTest
    {
        [Fact]
        public void ControllerTestAdd()
            => MyController<ProjectsController>
            .Instance(instance => instance.WithData(TenProjects()))
            .Calling(c => c.Add())
            .ShouldHave()
                .ActionAttributes(attributes => attributes
                                .RestrictingForAuthorizedRequests())
                .AndAlso()
            .ShouldReturn()
            .View();
        [Fact]
        public void DetailsShouldReturnView()
            => MyController<ProjectsController>
                .Calling(c => c.Details(int.MaxValue))
                .ShouldReturn()
                .View();

    }
}
