namespace ARS_ProjectSystem.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProjectsController:AdminController
    {
        public IActionResult Index() => View();
    }
    
}
