namespace ARS_ProjectSystem.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static AppUser.UserConstants;

    [Area(AreaName)]
    [Authorize(Roles = NormalUserRoleName)]
    public class ProjectsController:Controller
    {
        public IActionResult Index() => View();
    }
}
