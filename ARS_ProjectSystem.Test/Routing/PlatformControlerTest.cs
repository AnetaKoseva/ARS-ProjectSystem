namespace ARS_ProjectSystem.Test.Routing
{
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Models.Proposals;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class PlatformControlerTest
    {
        [Fact]
        public void PlatformPageRouteShouldBeMapped()
           => MyRouting
           .Configuration()
           .ShouldMap("/Platform/PlatformPage")
           .To<PlatformController>(c => c.PlatformPage());
        
    }
}
