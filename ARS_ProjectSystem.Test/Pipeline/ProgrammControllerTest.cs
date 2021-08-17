namespace ARS_ProjectSystem.Test.Pipeline
{
    using ARS_ProjectSystem.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    public class ProgrammControllerTest
    {
        [Fact]
        public void GetAddShouldBeForAuthorizedUsersAndReturnView()
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Programms/Add")
                    .WithUser())
                .To<ProgrammsController>(c => c.Add())
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
                    .WithPath("/Programms/All")
                    .WithUser())
                .To<ProgrammsController>(c => c.All())
                .Which()
                .ShouldReturn()
                .View();
    }
}
