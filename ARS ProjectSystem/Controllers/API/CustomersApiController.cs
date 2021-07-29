namespace ARS_ProjectSystem.Controllers.Api
{
    using ARS_ProjectSystem.Data.Models;
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

        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult GetDetails(int id)
        //{
        //    var customer= this.data.Customers.Find(id);
            
        //    if(customer==null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(id);
        //}
        
        //update
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id,Customer customer)
        {
            if(id!=customer.Id)
            {
                return BadRequest();
            }
            //this.productService.EditProduct(id, customer);
            return NoContent();
        }
        //delete
        //[HttpDelete("{id}")]
        //public ActionResult<Customer>DeleteCustomer(int id)
        //{
        //    //var customer = this.productService.DeleteCustomer(id);
        //    if(customer==null)
        //    {
        //        return NotFound();
        //    }
        //    return customer;
        //}
    }
}
