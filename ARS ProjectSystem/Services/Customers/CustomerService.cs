namespace ARS_ProjectSystem.Services.Customers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using System.Linq;

    public class CustomerService:ICustomerService
    {
        private readonly ProjectSystemDbContext data;

        public CustomerService(ProjectSystemDbContext data)
        {   
            this.data = data;
        }

        public string Add(
            string name,
            string registrationNumber,
            string VAT,
            string ownerName,
            string phoneNumber,
            string email,
            string url,
            string address,
            string town,
            string country)
        {
            var customerData = new Customer();

            if (!this.data.Customers.Any(c => c.RegistrationNumber == registrationNumber))
            {
                 customerData = new Customer
                {
                    Name = name,
                    RegistrationNumber = registrationNumber,
                    VAT = VAT,
                    OwnerName = ownerName,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    Url = url,
                    Address = address,
                    Town = town,
                    Country = country,
                };

                this.data.Customers.Add(customerData);
                this.data.SaveChanges();
            }

            return customerData.RegistrationNumber;
        }

        public CustomerQueryServiceModel All(string searchTerm)
        {

            var customerQuery = this.data.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                customerQuery = customerQuery.Where(c =>
                    c.Name.ToLower().Contains(searchTerm.ToLower())
                    || c.OwnerName.ToLower().Contains(searchTerm.ToLower())
                    ||c.RegistrationNumber.ToLower().Contains(searchTerm.ToLower())
                    ||c.VAT.ToLower().Contains(searchTerm.ToLower())
                    ||c.RegistrationNumber.ToLower().Contains(searchTerm.ToLower()));
            }

            var customers = customerQuery
                .OrderBy(c => c.Name)
                .Select(c => new CustomerServiceModel
                {
                    Name = c.Name,
                    RegistrationNumber = c.RegistrationNumber,
                    VAT = c.VAT,
                    OwnerName = c.OwnerName
                })
                .ToList();

            return new CustomerQueryServiceModel
            {
                Customers = customers,
                SearchTerm = searchTerm
            };
        }

        public string Delete(string id)
        {
            var customer = this.data.Customers.FirstOrDefault(c => c.RegistrationNumber == id);
            var employees = this.data.Employees.Where(c => c.CustomerRegistrationNumber == id).ToList();

            foreach (var employee in employees)
            {
                this.data.Employees.Remove(employee);
            }

            this.data.Customers.Remove(customer);
            this.data.SaveChanges();

            return customer.RegistrationNumber;
        }
    }
}
