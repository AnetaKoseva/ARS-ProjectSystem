namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Infrastructure;
    using ARS_ProjectSystem.Models.ProjectSystemUsers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class ProjectSystemUserController:Controller
    {
        private readonly ProjectSystemDbContext data;
        public ProjectSystemUserController(ProjectSystemDbContext data)
            => this.data = data;

        [Authorize]
        public IActionResult Create() => View();
        [HttpPost]
        [Authorize]
        public IActionResult Create(BecomeProjectSystemUserFormModel user)
        {
            var userId = this.User.GetId();
            var userIsAlredyProjectSytemUser = this.data
                .ProjectSystemUsers
            .Any(psu=>psu.UserId==userId);
            if (userIsAlredyProjectSytemUser)
            {
                return BadRequest();
            }
            if(!ModelState.IsValid)
            {
                return View(user);
            }
            var projectSystemUserData = new ProjectSystemUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                 UserId= userId
            };
            this.data.ProjectSystemUsers.Add(projectSystemUserData);
            this.data.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}
