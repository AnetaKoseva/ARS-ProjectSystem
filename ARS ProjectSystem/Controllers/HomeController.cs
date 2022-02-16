namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Models.Home;
    using ARS_ProjectSystem.Services.Projects;
    using ARS_ProjectSystem.Services.Statistics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly IProjectService projects;
        private readonly IStatisticsService statistics;
        //private readonly IMemoryCache cache;
        private readonly IDistributedCache cacheService;
        private readonly IConfiguration configuration;

        public HomeController(IStatisticsService statistics,
            IProjectService projects, 
            //IMemoryCache memoryCache
            IDistributedCache cacheService,
            IConfiguration iConfig
            )
        {
            this.statistics = statistics;
            this.projects = projects;
            //this.cache = memoryCache;
            this.cacheService = cacheService;
            this.configuration = iConfig;
        }

        public async Task<IActionResult> Index()
        {
            var totalStatistics = this.statistics.Total();

            //var totalProjects = this.projects.Total();

            ////if (!cache.TryGetValue<IEnumerable<ProjectTotalServiceModel>>("total", out var totalProjects))
            ////{
            ////    totalProjects = this.projects.Total();
            ////    //how long to be cached
            ////    cache.Set("total", totalProjects,TimeSpan.FromDays(1));
            ////}
            var dataAsString =await this.cacheService.GetStringAsync("TotalInfo");
            IEnumerable<ProjectTotalServiceModel> totalProjects;
            if (dataAsString == null)
            {
                totalProjects = this.projects.Total();
                await this.cacheService.SetStringAsync("TotalInfo", JsonConvert.SerializeObject(totalProjects),
                    new DistributedCacheEntryOptions
                    {
                        SlidingExpiration = new TimeSpan(24, 0, 0)
                    }); ;
            }
            else
            {
                totalProjects =JsonConvert.DeserializeObject<IEnumerable<ProjectTotalServiceModel>>(dataAsString);
            }

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

        [HttpPost]
        public async Task<IActionResult>SendToEmail(int id)
        {
            
            var apiKey = configuration.GetSection("SendGrid").GetSection("ApiKey").Value;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("office@ars-consult.eu");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("ayordanova@ars-consult.eu");

            var project = this.projects.AllProjects().FirstOrDefault(p => p.Id == id);
            var html = new StringBuilder();
            html.AppendLine($"<h1>{project.Name}<h1>");
            html.AppendLine($"<h3>{project.ProjectPhoto}<h3>");

            var plainTextContent = $"<h1>{project.Name}<h1>";
            var htmlContent = html.ToString();
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            
            await client.SendEmailAsync(msg);
            
           return RedirectToAction("Index", "Home");
        }
    }
}
