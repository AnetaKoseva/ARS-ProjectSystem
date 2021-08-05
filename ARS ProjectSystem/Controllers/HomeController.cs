namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Models;
    using ARS_ProjectSystem.Models.Home;
    using ARS_ProjectSystem.Services.Statistics;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Linq;
    public class HomeController : Controller
    {
        private readonly ProjectSystemDbContext data;
        private readonly IMapper mapper;
        private readonly IStatisticsService statistics;

        public HomeController(IStatisticsService statistics,
            IMapper mapper, ProjectSystemDbContext data)
        {
            this.statistics = statistics;
            this.mapper = mapper;
            this.data = data;
        }

        public IActionResult Index()
        {
            var totalStatistics = this.statistics.Total();
            //automapper in select and register in mappingProfile
            var projects=this.data
                .Projects
                .OrderByDescending(p=>p.Id)
                .ProjectTo<ProjectIndexViewModel>(this.mapper.ConfigurationProvider)
                .ToList();
            //var projects = this.data
            //    .Projects
            //    .OrderByDescending(p => p.Id)
            //    .Select(p => new ProjectIndexViewModel
            //    {
            //        Id = p.Id,
            //        Name=p.Name,
            //        ProjectPhoto=p.ProjectPhoto,
            //        ProgrammName=p.Programm.ProgrammName
            //    })
            //    .ToList();

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
