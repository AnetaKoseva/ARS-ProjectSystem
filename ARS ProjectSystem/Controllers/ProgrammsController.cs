namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Programms;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class ProgrammsController : Controller
    {
        private readonly ProjectSystemDbContext data;
        public ProgrammsController(ProjectSystemDbContext data)
            => this.data = data;
        [Authorize]
        public IActionResult Add()=>View();
        
        public IActionResult All()
        {
            var programms = this.data.Programms.Select(p => new ProgrammListingViewModel
            {
                Id=p.Id,
                ProgrammName = p.ProgrammName,
                Description = p.Description.Substring(0, 80),
                FullDescription = p.Description,
                Url = p.Url
            }).ToList();
            if (programms != null)
            {
                return View(programms);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddProgrammFormModel programm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var programmData = new Programm
            {
                ProgrammName = programm.ProgrammName,
                Url = programm.Url,
                Description = programm.Description
            };
            this.data.Programms.Add(programmData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
       
        public IActionResult Details(string programmId)
        {
            var programm = this.data.Programms
                .First(t => t.Id == int.Parse(programmId));

            return this.View(programm);
        }
        public IActionResult Delete(int id)
        {
            var programm = this.data.Programms.FirstOrDefault(p => p.Id == id);
            this.data.Remove(programm);
            this.data.SaveChanges();
            return RedirectToAction(nameof(All));
        }
    }
}
