namespace ARS_ProjectSystem.Test.Mocks
{
    using Microsoft.Extensions.Caching.Distributed;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DistributedCacheMocks
    {
        public static IDistributedCache Cache
        {
            
            get
            {
                var statisticsServiceMock = new Mock<IDistributedCache>();
                
                return statisticsServiceMock.Object;
            }
        }
    }
}
