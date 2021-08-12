namespace ARS_ProjectSystem.Test.Controllers
{
    using System.Linq;
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using ARS_ProjectSystem.Controllers;


    public class CustomersControllerTest
    {
        [Fact]
        public void ControllerTestAdd()
            => MyController<CustomersController>
            .Instance()
            .Calling(c => c.Add())
            .ShouldReturn()
            .View();
        [Fact]
        public void ControllerTestAll()
            => MyMvc
            .Pipeline()
            .ShouldMap(request => request.WithPath("/Employees/All"))
            .To<EmployeesController>(c => c.All())
            .Which()
            .ShouldReturn()
            .View();
    }
}
