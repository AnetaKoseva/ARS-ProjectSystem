namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Models;
    using ARS_ProjectSystem.Models.Home;
    using ARS_ProjectSystem.Services.Statistics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    public class HomeController : Controller
    {
        private readonly ProjectSystemDbContext data;
        private readonly IStatisticsService statistics;


        public HomeController(IStatisticsService statistics,
            ProjectSystemDbContext data)
        {
            this.statistics = statistics;
            this.data = data;
        }

        public IActionResult Index()
        {
            var totalStatistics = this.statistics.Total();

            var projects = this.data
                .Projects
                .OrderByDescending(p => p.Id)
                .Select(p => new ProjectIndexViewModel
                {
                    Id = p.Id,
                    Name=p.Name,
                    ProjectPhoto=p.ProjectPhoto,
                    ProgrammName=p.Programm.ProgrammName
                })
                .ToList();

            return View(new IndexViewModel
            {
                  TotalCustomers=totalStatistics.TotalCustomers,
                  TotalProjects=totalStatistics.TotalProjects,
                  TotalProposals= totalStatistics.TotalProposals,
                  Projects=projects
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
