namespace ARS_ProjectSystem.Test.Services
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Services.Customers;
    using ARS_ProjectSystem.Test.Mocks;
    using Xunit;
    using System.Linq;

    public class CustomerServiceTest
    {
        [Fact]
        public void AllSearchShoudReturnSearchedCustomers()
        {
            const string searchTerm = "Aneta";

            using var data = DatabaseMock.Instance;

            var customer = data.Customers.Add(new Customer 
            { 
                RegistrationNumber = "999999999",
                Name = "Aneta" 
            });

            data.SaveChanges();

            var customerService = new CustomerService(data);

            var result = customerService.All(searchTerm);
            var count = result.Customers.Count();
            var regnmub = result.Customers.Single();

            Assert.NotNull(result);
            Assert.Equal(1, count);
        }

        [Fact]
        public void AllShoudReturnAllCustomers()
        {
            using var data = DatabaseMock.Instance;

            var customer = data.Customers.Add(new Customer 
            { 
                RegistrationNumber = "999999999",
                Name = "Aneta" 
            });

            data.SaveChanges();

            var customerService = new CustomerService(data);

            var result = customerService.All(string.Empty);
            var count = result.Customers.Count();
            var regnmub = result.Customers.Single();

            Assert.NotNull(result);
            Assert.Equal(1, count);
        }

        [Fact]
        public void AddShoudReturnAllCustomers()
        {
            using var data = DatabaseMock.Instance;

            var customerService = new CustomerService(data);

            customerService.Add("ARS",
            "203300624",
            "BG203300624",
            "Aneta Koseva",
            "088888888",
            "ars@ars.eu",
            "https:\\ars-consult.eu",
            "xxx",
            "xxxxx",
            "xxxx");

            var count = data.Customers.Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public void DeleteShoudReturnAllCustomers()
        {
            using var data = DatabaseMock.Instance;

            var customer = data.Customers.Add(new Customer { RegistrationNumber = "999999999", Name = "Aneta" });
            var customer2 = data.Customers.Add(new Customer { RegistrationNumber = "888888888", Name = "Alisa" });
            var employee = data.Employees.Add(new Employee { CustomerRegistrationNumber = "888888888" });
            
            data.SaveChanges();

            var customerService = new CustomerService(data);
            customerService.Delete(customer2.Entity.RegistrationNumber);

            var count = data.Customers.Count();
            var employeeCount = data.Employees.Count();

            Assert.Equal(1, count);
            Assert.Equal(0, employeeCount);
        }
    }
}
