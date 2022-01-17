namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Home;
    using ARS_ProjectSystem.Services.Projects;
    using ARS_ProjectSystem.Services.Statistics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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

        public IActionResult Contact()
        {
            return View();
        }
        [Authorize(Roles ="Administrator")]
        public  IActionResult Charts()
        {

                return View();

        }
       
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Team()
        {
            return View();
        }
        public IActionResult Testimonials()
        {
            return View();
        }
        public IActionResult Index1()
        {
            return View();
        }
    }
}
