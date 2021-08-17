namespace ARS_ProjectSystem.Controllers.Api
{
    using ARS_ProjectSystem.Models.Api.Customers;
    using ARS_ProjectSystem.Services.Customers;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/customers")]
    public class CustomersApiController:ControllerBase
    {
        private readonly ICustomerService customers;

        public CustomersApiController(ICustomerService customers)
            => this.customers = customers;

        [HttpGet]
        public ActionResult<CustomerQueryServiceModel> All([FromQuery] AllCustomersApiRequestModel query)
            =>this.customers.All(query.SearchTerm);
    }
}
