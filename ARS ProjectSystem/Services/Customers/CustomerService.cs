namespace ARS_ProjectSystem.Services.Customers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Customers;
    using System.Linq;

    public class CustomerService:ICustomerService
    {
        private readonly ProjectSystemDbContext data;

        public CustomerService(ProjectSystemDbContext data)
        {   
            this.data = data;
        }

        public string Add(AddCustomerFormModel customer)
        {
            var customerData = new Customer();

            if (!this.data.Customers.Any(c => c.RegistrationNumber == customer.RegistrationNumber))
            {
                 customerData = new Customer
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

        public bool Edit(AddCustomerFormModel customer)
        {
            var customerData = this.data.Customers.Find(customer.RegistrationNumber);

            customerData.Name = customer.Name;
            customerData.RegistrationNumber = customerData.RegistrationNumber;
            customerData.VAT = customerData.VAT;
            customerData.OwnerName = customerData.OwnerName;
            customerData.Country = customerData.Country;
            customerData.Address = customerData.Address;
            customerData.Url = customerData.Url;
            customerData.Email = customerData.Email;
            customerData.PhoneNumber = customerData.PhoneNumber;
            customerData.Town = customerData.Town;

            this.data.SaveChanges();

            return true;
        }

        public CustomerQueryServiceModel GetById(string searchTerm, string id)
        {
            var user = this.data.Users.FirstOrDefault(x => x.Id == id);
            var customerQuery = this.data.Customers.Where(x => x.RegistrationNumber == user.Number);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                customerQuery = customerQuery.Where(c =>
                    c.Name.ToLower().Contains(searchTerm.ToLower())
                    || c.OwnerName.ToLower().Contains(searchTerm.ToLower())
                    || c.RegistrationNumber.ToLower().Contains(searchTerm.ToLower())
                    || c.VAT.ToLower().Contains(searchTerm.ToLower())
                    || c.RegistrationNumber.ToLower().Contains(searchTerm.ToLower()));
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

        public AddCustomerFormModel GetCustomerById(string id)
        {
            var customerData = this.data.Customers.FirstOrDefault(c => c.RegistrationNumber == id);
            var customer = new AddCustomerFormModel { 
                Name=customerData.Name,
                RegistrationNumber=customerData.RegistrationNumber,
                VAT=customerData.VAT,
                OwnerName=customerData.OwnerName,
                Country=customerData.Country,
                Address=customerData.Address,
                Url=customerData.Url,
                Email=customerData.Email,
                PhoneNumber=customerData.PhoneNumber,
                Town=customerData.Town                 
            };
            return customer;
        }

        public string GetNameById(string id)
        {
            var customer = this.data.Customers.FirstOrDefault(c => c.RegistrationNumber == id);
            return customer.Name;
        }
    }
}
