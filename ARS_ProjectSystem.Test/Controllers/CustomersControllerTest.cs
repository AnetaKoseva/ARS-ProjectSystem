namespace ARS_ProjectSystem.Test.Controllers
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using ARS_ProjectSystem.Controllers;

    public class CustomersControllerTest
    {
        [Fact]
        public void AddActionShouldReturnCorrectViewWithModel()
           => MyController<CustomersController>
           .Instance()
           .Calling(c => c.Add())
           .ShouldHave()
           .ActionAttributes(attributes => attributes
                                .RestrictingForAuthorizedRequests())
           .AndAlso()
           .ShouldReturn()
           .View();

        [Fact]
        public void AllActionShouldReturnCorrectViewWithModel()
           => MyController<CustomersController>
           .Instance()
           .Calling(c => c.All(new Models.Customers.AllCustomersQueryModel { SearchTerm= "aneta" }))
           .ShouldHave()
           .ActionAttributes(attributes => attributes
                                .RestrictingForAuthorizedRequests())
           .AndAlso()
           .ShouldReturn()
           .View();
    }
}
