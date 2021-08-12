namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Models.Platform;
    using ARS_ProjectSystem.Services.Platform;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class PlatformController:Controller
    {
        private readonly IPlatformService platform;
        public PlatformController(IPlatformService platform)
        {
            this.platform = platform;
        }
        public IActionResult PlatformPage()=> View();
        [Authorize]
        public IActionResult AddShortApplicationForm(int id,string customerName)
        {
            return View(new AddShortApplicationForm
            {
                ProposalId=id,
                CompanyName=customerName
            });
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddShortApplicationForm(AddShortApplicationForm application)
            => RedirectToAction("ShortApplication", "Platform",application);
        public IActionResult ShortApplication(AddShortApplicationForm application)
        {
            return View(application);
        }
        private IEnumerable<PlatformCustomersServiceModel> GetPlatformCustomers()
            => this.platform.GetPlatformCustomers();
    }
}
