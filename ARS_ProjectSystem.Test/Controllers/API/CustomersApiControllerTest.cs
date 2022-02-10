namespace ARS_ProjectSystem.Test.Controllers.API
{
    using ARS_ProjectSystem.Controllers.Api;
    using ARS_ProjectSystem.Models.Api.Customers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class CustomersApiControllerTest
    {
        [Fact]
        public void AllProjectsShoudReturnObject()
            => MyController<CustomersApiController>
           .Instance()
           .Calling(c => c.All(new AllCustomersApiRequestModel { SearchTerm = "aneta" }))
           .ShouldReturn()
           .Object();
    }
}
