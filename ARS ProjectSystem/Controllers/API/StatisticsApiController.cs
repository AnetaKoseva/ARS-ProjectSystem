namespace ARS_ProjectSystem.Controllers.API
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Models.Api.Statistics;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController:ControllerBase
    {
        private readonly ProjectSystemDbContext data;
        public StatisticsApiController(ProjectSystemDbContext data)
            => this.data = data;
        [HttpGet]
        public StatisticsResponseModel GetStatistics()
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
            var statistics = new StatisticsResponseModel
            {
                TotalProjects = totalProjects,
                TotalProposals= totalProposals,
                TotalCustomers=totalCustomers,
                TotalInvoices=totalInvoices
            };
            return statistics;
        }
    }
}
