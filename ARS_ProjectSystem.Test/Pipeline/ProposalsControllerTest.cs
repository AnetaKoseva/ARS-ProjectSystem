namespace ARS_ProjectSystem.Test.Pipeline
{
    using ARS_ProjectSystem.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    public class ProposalsControllerTest
    {
        [Fact]
        public void GetAddShouldBeForAuthorizedUsersAndReturnView()
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Proposals/Add")
                    .WithUser())
                .To<ProposalsController>(c => c.Add())
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
                    .WithPath("/Proposals/All")
                    .WithUser())
                .To<ProposalsController>(c => c.All())
                .Which()
                .ShouldReturn()
                .View();
    }
}
