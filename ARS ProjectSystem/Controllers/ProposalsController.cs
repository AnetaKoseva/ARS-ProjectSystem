namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Models.Proposals;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using System.Linq;

    using System.Collections.Generic;
    using ARS_ProjectSystem.Services.Proposals;

    public class ProposalsController:Controller
    {
        
        private readonly IProposalService proposals;
        public ProposalsController( IProposalService proposals)
        {
            this.proposals = proposals;
        }

        public IActionResult All()
        {
            var proposals = this.proposals.All();
            if (proposals != null)
            {
                return View(proposals);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Add() 
        {

            return View(new AddProposalFormModel
            {
                Customers = this.GetProposalCustomers()
            }) ;
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(AddProposalFormModel proposal)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            this.proposals.Create(
                proposal.Id,
                proposal.Name,
                proposal.CreatedOn,
                proposal.UrlPhoto,
                proposal.Budget,
                proposal.CustomerRegistrationNumber,
                proposal.ProjectId);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Details(int proposalId)
        {
            var proposal = this.proposals.Details(proposalId);

            return this.View(proposal);
        }
        private IEnumerable<ProposalCustomersServiceModel> GetProposalCustomers()
            => this.proposals.GetProposalCustomers();
        
    }
    
}
