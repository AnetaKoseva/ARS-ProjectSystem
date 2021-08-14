namespace ARS_ProjectSystem.Test.Routing
{
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Models.Proposals;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ProposalControllerTest
    {
        [Fact]
        public void GetAddRouteShouldBeMapped()
           => MyRouting
           .Configuration()
           .ShouldMap("/Proposals/Add")
           .To<ProposalsController>(c => c.Add());
        [Fact]
        public void GetAllRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request.WithPath("/Proposals/All")
            .WithMethod(HttpMethod.Post))
            .To<ProposalsController>(c => c.All());
        [Fact]
        public void PostAddRouteShouldBeMapperd()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request.WithPath("/Proposals/Add")
            .WithMethod(HttpMethod.Post))
            .To<ProposalsController>(c => c.Add(With.Any<ProposalFormModel>()));
    }
}
