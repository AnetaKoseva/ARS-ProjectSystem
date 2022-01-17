﻿namespace ARS_ProjectSystem.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static User.UserConstants;

    [Area(AreaName)]
    [Authorize(Roles = NormalUserRoleName)]
    public class ProjectsController:Controller
    {
        public IActionResult Index() => View();
    }
}
