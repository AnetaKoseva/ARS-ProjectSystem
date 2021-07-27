namespace ARS_ProjectSystem.Services.Statistics
{
    using ARS_ProjectSystem.Data;
    using System.Linq;

    public class StatisticsService : IStatisticsService
    {
        private readonly ProjectSystemDbContext data;
        public StatisticsService(ProjectSystemDbContext data)
            => this.data = data;
        public StatisticsServiceModel Total()
        {
            var totalProjects = this.data
                .Projects
                .Count();
            var totalCustomers = this.data
                .Customers
                .Count();
            var totalProposals = this.data
                .Proposals
                .Count();
            var totalInvoices = this.data
                .Invoices
                .Count();
            return new StatisticsServiceModel
            {
                TotalCustomers = totalCustomers,
                TotalInvoices = totalInvoices,
                TotalProjects = totalInvoices,
                TotalProposals = totalProposals
            };
        }
    }
}
