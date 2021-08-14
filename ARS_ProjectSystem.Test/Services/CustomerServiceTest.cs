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
        public void AllShoudReturnAllCustomers()
        {
            const string searchTerm = "Aneta";

            using var data = DatabaseMock.Instance;

            var customer=data.Customers.Add(new Customer { RegistrationNumber="999999999",Name="Aneta"});
            data.SaveChanges();

            var customerService = new CustomerService(data);

            var result = customerService.All(searchTerm);
            var count = result.Customers.Count();
            var regnmub = result.Customers.Single();
            
            Assert.NotNull(result);
            Assert.Equal(1, count);
        }
    }
}
