namespace ARS_ProjectSystem.Test.Controllers
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using ARS_ProjectSystem.Controllers;
    using static Data.ProjectSystem;
    using FluentAssertions;
    using ARS_ProjectSystem.Models.Invoices;
    using System.Collections.Generic;
    public class PlatformControllerTest
    {
        [Fact]
        public void PlatformPageReturnCorrectViewWithModel()
            => MyController<PlatformController>
            .Calling(c => c.PlatformPage())
            .ShouldReturn()
            .View();
    }
}
