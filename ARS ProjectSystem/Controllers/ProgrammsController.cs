namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Models.Programms;
    using ARS_ProjectSystem.Services.Programms;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;
    public class ProgrammsController : Controller
    {
        private readonly IProgrammService programms;

        public ProgrammsController( IProgrammService programms)
        {
            this.programms = programms;
        }

        [Authorize]
        public IActionResult Add()=>View();
        
        public IActionResult All()
        {
            var programmData = programms.All();

            if (programmData != null)
            {
                return View(programmData);
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

            this.programms.Create(
                programm.ProgrammName,
                programm.Url,
                programm.Description);

            TempData[GlobalMessageKey] = $"Programm {programm.ProgrammName} is added succesfully!";

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            var programmDta = programms.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
