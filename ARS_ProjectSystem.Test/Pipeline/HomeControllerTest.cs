namespace ARS_ProjectSystem.Test.Pipeline
{
    using ARS_ProjectSystem.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class HomeControllerTest
    {
        [Fact]
        public void GetAddShouldBeForAuthorizedUsersAndReturnView()
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Home/Index")
                    .WithUser())
                .To<HomeController>(c => c.Index())
                .Which()
                .ShouldReturn()
                .View();

        [Fact]
        public void GetAllShoulddReturnView()
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Home/Error")
                    .WithUser())
                .To<HomeController>(c => c.Error())
                .Which()
                .ShouldReturn()
                .View();
    }
}
