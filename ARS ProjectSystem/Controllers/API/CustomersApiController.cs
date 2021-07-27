namespace ARS_ProjectSystem.Controllers.Api
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Api.Customers;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    [ApiController]
    [Route("api/customers")]
    public class CustomersApiController:ControllerBase
    {
        ///*private readonly*/ ICustomerService customers;
        //public CustomersApi(ICustomerService customers)
        //    => this.customers = customers;
        private readonly ProjectSystemDbContext data;
        public CustomersApiController(ProjectSystemDbContext data)
            => this.data = data;
        
        [HttpGet]
        public ActionResult<AllCustomersApiResponseModel> All([FromQuery] AllCustomersApiRequestModel query)
        {
            var customerQuery = this.data.Customers.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                customerQuery = customerQuery.Where(c =>
                    c.Name.ToLower().Contains(query.SearchTerm.ToLower())
                    || c.RegistrationNumber.ToLower().Contains(query.SearchTerm.ToLower())
                    || c.OwnerName.ToLower().Contains(query.SearchTerm.ToLower())
                    || c.VAT.ToLower().Contains(query.SearchTerm.ToLower()));
            }
            var customers = customerQuery
                .OrderBy(c => c.Name)
                .Select(c => new CustomerResponseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    RegistrationNumber = c.RegistrationNumber,
                    VAT = c.VAT,
                    OwnerName = c.OwnerName
                })
                .ToList();
            return new AllCustomersApiResponseModel
            {
                Customers=customers,
                SearchTerm=query.SearchTerm
            };
            
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDetails(int id)
        {
            var customer= this.data.Customers.Find(id);
            
            if(customer==null)
            {
                return NotFound();
            }
            return Ok(id);
        }
        
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
