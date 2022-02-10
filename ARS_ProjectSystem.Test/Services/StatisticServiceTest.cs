namespace ARS_ProjectSystem.Test.Services
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Services.Proposals;
    using ARS_ProjectSystem.Services.Statistics;
    using ARS_ProjectSystem.Test.Mocks;
    using System.Linq;
    using Xunit;

    public class StatisticServiceTest
    {
        [Fact]
        public void TotalShouldReturnNotNullAndShouldReturnTotal()
        {
            using var data = DatabaseMock.Instance;

            data.Proposals.Add(new Proposal
            {
                Name = "ARS"
            });

            data.Projects.Add(new Project
            {
                Name = "ARS"
            });

            data.Customers.Add(new Customer
            {
                RegistrationNumber = "9999"
            });

            data.Invoices.Add(new Invoice
            {
                 Item = "ARS"
            });

            data.SaveChanges();

            var statisticlService = new StatisticsService(data);
            var result = statisticlService.Total();

            Assert.NotNull(result);
        }
    }
}
