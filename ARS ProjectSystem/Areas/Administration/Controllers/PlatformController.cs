namespace ARS_ProjectSystem.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    [Authorize]
    public class PlatformController:Controller
    {
        public IActionResult PlatformPage()=> View();
    }
}
