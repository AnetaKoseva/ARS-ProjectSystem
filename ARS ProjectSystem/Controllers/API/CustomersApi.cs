namespace ARS_ProjectSystem.Controllers.API
{
    using ARS_ProjectSystem.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections;
    using System.Linq;

    [ApiController]
    [Route("api/customers")]
    public class CustomersApi:ControllerBase
    {
        private readonly ProjectSystemDbContext data;
        public CustomersApi(ProjectSystemDbContext data)
            => this.data = data;
        [HttpGet]
        public IEnumerable GetCustomers()
        {
            return this.data.Customers.ToList();
        }
    }
}
