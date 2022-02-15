namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Services.Customers;
    using ARS_ProjectSystem.Models.Customers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;
    using ARS_ProjectSystem.Infrastructure;

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
            var userId = this.User.GetId();
            if(User.IsInRole("Administrator"))
            {
                var queryResult = this.customers.All(query.SearchTerm);

                query.Customers = queryResult.Customers;

                return View(query);
            }
            else
            {
                var queryResult = this.customers.GetById(query.SearchTerm, userId);

                query.Customers = queryResult.Customers;

                return View(query);
            }

            
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

        [HttpPost]
        [Authorize]
       
        public IActionResult Delete(string id)
        {
            var customerName = this.customers.GetNameById(id);
            var customerData = this.customers.Delete(id);

            TempData[GlobalMessageKey] = $"Customer {customerName} is deleted succesfully!";
            return RedirectToAction(nameof(All));
        }
    }
}
