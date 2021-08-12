namespace ARS_ProjectSystem.Test.Controllers
{
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Models.Projects;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using System.Collections.Generic;
    using System.Linq;
    using static Data.ProjectSystem;
    public class ProjectsControllerTest
    {
        [Fact]
        public void ControllerTestMine()
            => MyMvc
            .Pipeline()
            .ShouldMap(request => request.WithPath("/Projects/Mine")
            .WithUser())
            .To<ProjectsController>(c => c.Mine())
            .Which()
            //.ShouldHave()
            //.ActionAttributes(attributes => attributes.RestrictingForAuthorizedRequests())
            //.AndAlso()
            .ShouldReturn()
            .View();
        //=> MyController<ProjectsController>
        //.Instance()
        //.Calling(c => c.Mine())
        //.ShouldHave()
        //.ActionAttributes(attributes
        //=> attributes.RestrictingForAuthorizedRequests())
        //.AndAlso()
        //.ShouldReturn()
        //.View();
        [Fact]
        public void RouteTestMine()
            => MyRouting.Configuration().ShouldMap("/Projects/Mine")
            .To<ProjectsController>(c => c.Mine());

        [Fact]
        public void MineShouldBeForAuthorizedUsersAndReturnView()
        => MyMvc
            .Pipeline()
            .ShouldMap("/Projects/Mine")
            .To<ProjectsController>(c => c.Mine());
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
    }
}
