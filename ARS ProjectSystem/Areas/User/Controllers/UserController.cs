namespace ARS_ProjectSystem.Areas.User.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static User.UserConstants;

    [Area(AreaName)]
    [Authorize(Roles = NormalUserRoleName)]
    public class UserController:Controller
    {
    }
}
