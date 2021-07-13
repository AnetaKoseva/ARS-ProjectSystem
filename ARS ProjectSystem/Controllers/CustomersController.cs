namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Customers;
    using Microsoft.AspNetCore.Mvc;
    public class CustomersController:Controller
    {
        private readonly ProjectSystemDbContext data;
        public CustomersController(ProjectSystemDbContext data)
            => this.data = data;
        public IActionResult Add() => View();
        [HttpPost]
        public IActionResult Add(AddCustomerFormModel customer)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var customerData = new Customer
            {
                  Name=customer.Name,
                  RegistrationNumber=customer.RegistrationNumber,
                  VAT=customer.VAT,
                  OwnerName=customer.OwnerName,
                  PhoneNumber=customer.PhoneNumber,
                  Email = customer.Email,
                  Url=customer.Url,
                  Address =customer.Address,
                  Town=customer.Town,
                  Country=customer.Country,
            };
            this.data.Customers.Add(customerData);
            this.data.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}
