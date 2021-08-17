namespace ARS_ProjectSystem.Test.Pipeline
{
    using ARS_ProjectSystem.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class EmployeesControllerTest
    {
        [Fact]
        public void GetAddShouldBeForAuthorizedUsersAndReturnView()
           => MyPipeline
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Employees/Add")
                   .WithUser())
               .To<EmployeesController>(c => c.Add())
               .Which()
               .ShouldHave()
               .ActionAttributes(attributes => attributes
                   .RestrictingForAuthorizedRequests())
               .AndAlso()
               .ShouldReturn()
               .View();

        [Fact]
        public void GetAllShoulddReturnView()
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Employees/All")
                    .WithUser())
                .To<EmployeesController>(c => c.All())
                .Which()
                .ShouldReturn()
                .View();
    }
}

