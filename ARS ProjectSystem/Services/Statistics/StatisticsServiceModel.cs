namespace ARS_ProjectSystem.Services.Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class StatisticsServiceModel
    {
        public int TotalProjects { get; init; }
        public int TotalCustomers { get; init; }
        public int TotalProposals { get; init; }
        public int TotalInvoices { get; init; }
    }
}
