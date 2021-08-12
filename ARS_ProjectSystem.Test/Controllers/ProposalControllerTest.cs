namespace ARS_ProjectSystem.Test.Controllers
{
    using System.Collections.Generic;
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Models.Proposals;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using static Data.ProjectSystem;
    public class ProposalControllerTest
    {
        [Fact]
        public void ControllerTestAll()
            => MyController<ProposalsController>
            .Instance(instance=>instance.WithData(TenProposals))
            .Calling(c => c.All())
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<IEnumerable<AllProposalsListingViewModel>>().Passing(p => p.Should().HaveCount(10)));
        [Fact]
        public void ControllerTestAdd()
            => MyController<ProposalsController>
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
