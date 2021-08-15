namespace ARS_ProjectSystem.Test.Controllers
{
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Services.Employees;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    public class EmployeesControllerTest
    {
        [Fact]
        public void ControllerTestAll()
            => MyMvc
            .Pipeline()
            .ShouldMap(request => request.WithPath("/Employees/All"))
            .To<EmployeesController>(c => c.All())
            .Which()
            .ShouldReturn()
            .View();

        [Fact]
        public void RouteTest()
            =>MyRouting.Configuration().ShouldMap("/Employees/Add")
            .To<EmployeesController>(c=>c.Add());

        [Fact]
        public void ControllerTestAddToProposal()
            => MyController<EmployeesController>
            .Instance()
            .Calling(c => c.AddToProposal())
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<EmployeeProposalsFormModel>().Passing(p => p.Should().NotBeNull()));

        [Fact]
        public void ControllerTestAddToProjectl()
            => MyController<EmployeesController>
            .Instance()
            .Calling(c => c.AddToProject())
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<EmployeeProjectsFormModel>().Passing(p => p.Should().NotBeNull()));

        [Fact]
        public void AllActionShouldReturnCorrectViewWithModel()
           => MyController<EmployeesController>
           .Instance()
           .Calling(c => c.All())
           .ShouldReturn()
           .View();

        [Fact]
        public void ControllerTestAdd()
            => MyController<EmployeesController>
            .Instance()
            .Calling(c => c.Add())
            .ShouldReturn()
            .View();
    }
}
