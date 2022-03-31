namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.EmailSender;
    using ARS_ProjectSystem.Models.Home;
    using ARS_ProjectSystem.Services.Projects;
    using ARS_ProjectSystem.Services.Statistics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using static WebConstants;
    public class HomeController : Controller
    {
        private readonly IProjectService projects;
        private readonly IStatisticsService statistics;
        private readonly IContactEmailSender emailSender;
        //private readonly IMemoryCache cache;
        private readonly IDistributedCache cacheService;
        //private readonly IConfiguration configuration;

        public HomeController(IStatisticsService statistics,
            IProjectService projects, 
            //IMemoryCache memoryCache
            IDistributedCache cacheService,
            IContactEmailSender emailSender,
            IOptions<AuthMessageSenderOptions> optionsAccessor
            )
        {
            this.statistics = statistics;
            this.projects = projects;
            //this.cache = memoryCache;
            this.cacheService = cacheService;
            Options = optionsAccessor.Value;
            this.emailSender = emailSender;
        }

        public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

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

        [HttpPost]
        public  IActionResult Contact(ContactForm contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            emailSender.SendEmail(contact, Options.ApiKey);
            
            TempData[GlobalMessageKey] = $"Message is sended succesfully!";

            return RedirectToAction("Index", "Home");
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

        public IActionResult Stepper()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendToEmail(int id)
        {
            emailSender.SendToEmail(id, Options.ApiKey);

            TempData[GlobalMessageKey] = $"Project is sended succesfully!";
            return RedirectToAction("Index", "Home");
        }
    }
}
