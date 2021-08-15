namespace ARS_ProjectSystem.Test.Mocks
{
    using ARS_ProjectSystem.Services.Statistics;
    using Moq;

    public class StatisticsServiceMock
    {
        public static IStatisticsService Instance
        {
            get
            {
                var statisticsServiceMock = new Mock<IStatisticsService>();
                statisticsServiceMock.Setup(s => s.Total())
                    .Returns(new StatisticsServiceModel
                    {
                        TotalCustomers = 5,
                          TotalInvoices=5,
                           TotalProjects=5,
                            TotalProposals=5
                    });
                return statisticsServiceMock.Object;
            }
        }
    }
}
