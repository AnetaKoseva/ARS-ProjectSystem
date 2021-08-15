namespace ARS_ProjectSystem.Test.Controllers.API
{
    using ARS_ProjectSystem.Controllers.API;
    using ARS_ProjectSystem.Test.Mocks;
    using Xunit;

    public class StatisticsApiControllerTest
    {
        [Fact]
        public void etStatisticsShoudReturnTotalStatistics()
        {
            //Arrange
            var statisticsController = new StatisticsApiController(StatisticsServiceMock.Instance);
            //Act
            var result = statisticsController.GetStatistics();
            //Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.TotalCustomers);
            Assert.Equal(5, result.TotalInvoices);
            Assert.Equal(5, result.TotalProjects);
            Assert.Equal(5, result.TotalProposals);
        }
    }
}
