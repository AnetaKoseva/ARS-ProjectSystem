namespace ARS_ProjectSystem.Test.Controllers
{

    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Models.Customers;

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
        //[Theory]
        //[InlineData("123")]
        //public void DeleteShoulReturnCorrectViewModel(string id)
        //=> MyController<CustomersController>
        //    .Calling(c => c.Delete(id))
        //    .ShouldReturn()
        //    .Redirect();
            
    }
}
