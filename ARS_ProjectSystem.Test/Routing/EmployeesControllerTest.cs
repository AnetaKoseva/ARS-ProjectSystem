namespace ARS_ProjectSystem.Test.Routing
{
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Models.Employees;
    using ARS_ProjectSystem.Models.Projects;
    using ARS_ProjectSystem.Services.Employees;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class EmployeesControllerTest
    {
        [Fact]
        public void GetAllRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Employees/All")
            .To<EmployeesController>(c => c.All());

        [Fact]
        public void GetAddRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Employees/Add")
            .To<EmployeesController>(c => c.Add());

        [Fact]
        public void PostAddRouteShouldBeMapperd()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request.WithPath("/Employees/Add")
            .WithMethod(HttpMethod.Post))
            .To<EmployeesController>(c => c.Add(With.Any<EmployeeFormModel>()));
    }
}
