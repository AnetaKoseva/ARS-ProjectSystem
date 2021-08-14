namespace ARS_ProjectSystem.Test.Routing
{
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Models.Customers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class CustommersControllerTest
    {
        [Fact]
        public void GetAddRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Customers/Add")
            .To<CustomersController>(c => c.Add());
        [Fact]
        public void GetAllRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request.WithPath("/Customers/All")
            .WithMethod(HttpMethod.Post))
            .To<CustomersController>(c => c.All(With.Any<AllCustomersQueryModel >()));
        [Fact]
        public void PostAddRouteShouldBeMapperd()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request.WithPath("/Customers/Add")
            .WithMethod(HttpMethod.Post))
            .To<CustomersController>(c => c.Add(With.Any<AddCustomerFormModel>()));
    }
}
