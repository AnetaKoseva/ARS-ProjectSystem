namespace ARS_ProjectSystem.Test.Mocks
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Customers;
    using ARS_ProjectSystem.Services.Customers;
    using ARS_ProjectSystem.Services.Statistics;
    using Moq;
    using System.Collections.Generic;
    using Xunit;

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
        [Fact]
        public void ReturnResult()
        {
            var statisticsServiceMock = new Mock<IStatisticsService>();
            statisticsServiceMock.Setup(s => s.Total())
                .Returns(new StatisticsServiceModel
                {
                    TotalCustomers = 5,
                    TotalInvoices = 5,
                    TotalProjects = 5,
                    TotalProposals = 5
                });
             
            
            var result= statisticsServiceMock.Object.Total();
            Assert.Equal(5,result.TotalCustomers);
        }
    }
}
