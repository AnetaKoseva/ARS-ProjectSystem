namespace ARS_ProjectSystem.Test.Controllers.API
{
    using ARS_ProjectSystem.Controllers.API;
    using ARS_ProjectSystem.Test.Mocks;
    using Xunit;

    public class StatisticsApiControllerTest
    {
        [Fact]
        public void GetStatisticsShoudReturnTotalStatistics()
        {
            var statisticsController = new StatisticsApiController(StatisticsServiceMock.Instance);

            var result = statisticsController.GetStatistics();

            Assert.NotNull(result);
            Assert.Equal(5, result.TotalCustomers);
            Assert.Equal(5, result.TotalInvoices);
            Assert.Equal(5, result.TotalProjects);
            Assert.Equal(5, result.TotalProposals);
        }
    }
}
