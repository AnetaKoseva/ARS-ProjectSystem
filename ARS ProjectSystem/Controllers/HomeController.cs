namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Models.Home;
    using ARS_ProjectSystem.Services.Projects;
    using ARS_ProjectSystem.Services.Statistics;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IProjectService projects;
        private readonly IStatisticsService statistics;

        public HomeController(IStatisticsService statistics,
            IProjectService projects)
        {
            this.statistics = statistics;
            this.projects = projects;
        }

        public IActionResult Index()
        {
            var totalStatistics = this.statistics.Total();
            var totalProjects = this.projects.Total();

            return View(new IndexViewModel
            {
                  TotalCustomers=totalStatistics.TotalCustomers,
                  TotalProjects=totalStatistics.TotalProjects,
                  TotalProposals= totalStatistics.TotalProposals,
                  Projects=totalProjects
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
