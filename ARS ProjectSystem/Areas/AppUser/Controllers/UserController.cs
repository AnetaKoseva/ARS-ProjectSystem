namespace ARS_ProjectSystem.Areas.AppUser.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static AppUser.UserConstants;

    [Area(AreaName)]
    [Authorize(Roles = NormalUserRoleName)]
    public class UserController:Controller
    {
    }
}
