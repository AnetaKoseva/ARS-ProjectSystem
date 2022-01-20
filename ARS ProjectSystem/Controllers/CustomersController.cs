namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Services.Customers;
    using ARS_ProjectSystem.Models.Customers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;
    public class CustomersController:Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [Authorize]
        public IActionResult Add()=>View();

        [Authorize]
        public IActionResult All([FromQuery] AllCustomersQueryModel query)
        {
            var queryResult = this.customers.All(query.SearchTerm);

            query.Customers = queryResult.Customers;

            return View(query);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddCustomerFormModel customer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            this.customers.Add(customer);

            TempData[GlobalMessageKey] = $"Customer {customer.Name} is added succesfully!";

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            var customerData = this.customers.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
