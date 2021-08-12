namespace ARS_ProjectSystem.Test.Services
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Services.Customers;
    using ARS_ProjectSystem.Test.Mocks;
    using Xunit;

    public class CustomerServiceTest
    {
        [Fact]
        public void AllShoudReturnAllCustomers()
        {
            //Arrange
            const string searchTerm = "Aneta";
            using var data = DatabaseMock.Instance;
            data.Customers.Add(new Customer { RegistrationNumber="999999999",
             Name="ARS", Address="Patr.Evtimii 121", Country="Bulgaria", Email="ars@consult.eu", OwnerName="Aneta",
             Town="Stara Zagora", VAT="999999999"});
            data.SaveChanges();
            var customerService = new CustomerService(data);
            //Act
            var result = customerService.All(searchTerm);
            Assert.NotNull(result);
        }
    }
}
