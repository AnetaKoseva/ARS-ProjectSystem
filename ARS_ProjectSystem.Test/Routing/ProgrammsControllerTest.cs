namespace ARS_ProjectSystem.Test.Routing
{
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Models.Programms;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    public class ProgrammsControllerTest
    {
        [Fact]
        public void GetAddRouteShouldBeMapped()
          => MyRouting
          .Configuration()
          .ShouldMap("/Programms/Add")
          .To<ProgrammsController>(c => c.Add());
        [Fact]
        public void GetAllRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request.WithPath("/Programms/All")
            .WithMethod(HttpMethod.Post))
            .To<ProgrammsController>(c => c.All());
        [Fact]
        public void PostAddRouteShouldBeMapperd()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request.WithPath("/Programms/Add")
            .WithMethod(HttpMethod.Post))
            .To<ProgrammsController>(c => c.Add(With.Any<AddProgrammFormModel>()));
    }
}
