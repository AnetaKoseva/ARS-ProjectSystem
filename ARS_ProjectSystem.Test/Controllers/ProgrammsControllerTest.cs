namespace ARS_ProjectSystem.Test.Controllers
{
    using System.Collections.Generic;
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Services.Programms;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using static Data.ProjectSystem;

    public class ProgrammsControllerTest
    {
        [Fact]
        public void ControllerTestAll()
            => MyController<ProgrammsController>
            .Instance(instance => instance.WithData(TenProgramms))
            .Calling(c => c.All())
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<List<ProgrammServiceModel>>().Passing(p => p.Should().HaveCount(10)));

        [Fact]
        public void ControllerTestAdd()
                => MyController<ProgrammsController>
                .Instance()
                .Calling(c => c.Add())
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                                .RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View();
    }
}
