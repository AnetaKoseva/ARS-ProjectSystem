namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Models.Proposals;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Programms;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class ProposalsController:Controller
    {
        private readonly ProjectSystemDbContext data;
        public ProposalsController(ProjectSystemDbContext data)
            => this.data = data;
        [Authorize]
        public IActionResult Add() => View();
        [HttpPost]
        [Authorize]
        public IActionResult Add(AddProposalFormModel proposal)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var proposalData = new Proposal
            {
                Name = proposal.Name,
                CreatedOn = proposal.CreatedOn,
                UrlPhoto = proposal.UrlPhoto,
                Budget=proposal.Budget
            };
            this.data.Proposals.Add(proposalData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
    
}
