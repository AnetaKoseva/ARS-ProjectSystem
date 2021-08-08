namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Services.Customers;
    using ARS_ProjectSystem.Models.Customers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class CustomersController:Controller
    {
        private readonly ProjectSystemDbContext data;
        public CustomersController(ProjectSystemDbContext data)
            => this.data = data;
        [Authorize]
        public IActionResult Add()=>View();
        [Authorize]
        public IActionResult All([FromQuery] AllCustomersQueryModel query)
        {
            var customerQuery = this.data.Customers.AsQueryable();
            if(!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                customerQuery = customerQuery.Where(c =>
                    c.Name.ToLower().Contains(query.SearchTerm.ToLower())
                    ||c.RegistrationNumber.ToLower().Contains(query.SearchTerm.ToLower())
                    ||c.OwnerName.ToLower().Contains(query.SearchTerm.ToLower())
                    ||c.VAT.ToLower().Contains(query.SearchTerm.ToLower()));
            }
            var customers = customerQuery
                .OrderBy(c=>c.Name)
                .Select(c => new CustomerServiceModel
            {
                Name=c.Name,
                RegistrationNumber=c.RegistrationNumber,
                VAT=c.VAT,
                OwnerName=c.OwnerName
                
              })
                .ToList();
                return View(new AllCustomersQueryModel
                {
                      Customers=customers,
                      SearchTerm= query.SearchTerm
                });
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(AddCustomerFormModel customer)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            if(!this.data.Customers.Any(c=>c.RegistrationNumber == customer.RegistrationNumber))
            {
                var customerData = new Customer
                {
                    Name = customer.Name,
                    RegistrationNumber = customer.RegistrationNumber,
                    VAT = customer.VAT,
                    OwnerName = customer.OwnerName,
                    PhoneNumber = customer.PhoneNumber,
                    Email = customer.Email,
                    Url = customer.Url,
                    Address = customer.Address,
                    Town = customer.Town,
                    Country = customer.Country,
                };
                this.data.Customers.Add(customerData);
                this.data.SaveChanges();
            }
            

            return RedirectToAction(nameof(All));
        }
        [Authorize]
        public IActionResult Delete(string id)
        {
            var customer = this.data.Customers.FirstOrDefault(c => c.RegistrationNumber == id);
            var employees = this.data.Employees.Where(c => c.CustomerRegistrationNumber == id).ToList();
            foreach (var employee in employees)
            {
                this.data.Employees.Remove(employee);
            }
            this.data.Customers.Remove(customer);
            this.data.SaveChanges();
            return RedirectToAction(nameof(All));
        }
    }
}
