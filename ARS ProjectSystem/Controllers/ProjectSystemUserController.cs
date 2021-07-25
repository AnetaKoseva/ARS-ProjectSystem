namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    public class ProjectSystemUserController:Controller
    {
        private readonly ProjectSystemDbContext data;
        [Authorize]
        public IActionResult Create() => View();
        //[HttpPost]
        //[Authorize]
        //public IActionResult Create()
        //{

        //}
    }
}
