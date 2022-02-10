namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class IdentityController:Controller
    {
        private readonly UserManager<User> userManager;
        public IdentityController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult>WhoAmI()
        {
            
            var user = await this.userManager.GetUserAsync(this.User);
            
            user.Number.Contains("999999");
            
            return this.Json(user);
        }
    }
}
