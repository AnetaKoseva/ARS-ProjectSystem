namespace ARS_ProjectSystem.Test.Controllers
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using ARS_ProjectSystem.Controllers;
    using static Data.ProjectSystem;
    using FluentAssertions;
    using ARS_ProjectSystem.Models.Home;

    public class HomeControllerTestnew
    {
        [Fact]
        public void IndexActionShouldReturnCorrectViewWithModel()
            => MyController<HomeController>
            .Instance(instance => instance
            .WithData(TenProjects()))
            .Calling(c=>c.Index())
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<IndexViewModel>().Passing(p => p.Should().NotBeNull()));

        [Fact]
        public void ErrorShouldReturnView()
                => MyController<HomeController>
                    .Instance()
                    .Calling(c => c.Error())
                    .ShouldReturn()
                    .View();
    }
}
