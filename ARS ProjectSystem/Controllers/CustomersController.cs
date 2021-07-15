namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Customers;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class CustomersController:Controller
    {
        private readonly ProjectSystemDbContext data;
        public CustomersController(ProjectSystemDbContext data)
            => this.data = data;
        public IActionResult Add() => View();
        public IActionResult All(string searchTerm)
        {
            var customerQuery = this.data.Customers.AsQueryable();
            if(!string.IsNullOrWhiteSpace(searchTerm))
            {
                customerQuery = customerQuery.Where(c =>
                    c.Name.ToLower().Contains(searchTerm.ToLower())
                    ||c.RegistrationNumber.ToLower().Contains(searchTerm.ToLower())
                    ||c.OwnerName.ToLower().Contains(searchTerm.ToLower())
                    ||c.VAT.ToLower().Contains(searchTerm.ToLower()));
            }
            var customers = customerQuery
                .OrderBy(c=>c.Name)
                .Select(c => new CustomerListingViewModel
            {
                Id = c.Id,
                Name=c.Name,
                RegistrationNumber=c.RegistrationNumber,
                VAT=c.VAT,
                OwnerName=c.OwnerName
              })
                .ToList();
                return View(new AllCustomersQueryModel
                {
                      Customers=customers,
                      SearchTerm=searchTerm
                });
        }
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

            return RedirectToAction(nameof(All));
        }
    }
}
