namespace ARS_ProjectSystem.Test.Controllers
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using ARS_ProjectSystem.Areas.Administration.Controllers;

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
