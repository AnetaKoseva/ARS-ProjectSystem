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
        private readonly ProjectSystemDbContext data;
        public ProposalsController(ProjectSystemDbContext data)
            => this.data = data;

        public IActionResult All()
        {
            var proposals = this.data.Proposals.Select(p => new AllProposalsListingViewModel
            {
                Id = p.Id,
                Name=p.Name,
                CustomerRegistrationNumber=p.CustomerRegistrationNumber,
                CustomerName=p.Customer.Name,
                Budget=p.Budget,
                CreatedOn=p.CreatedOn,
            }).ToList();
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
            var proposalData = new Proposal
            {
                Id=proposal.Id,
                Name = proposal.Name,
                CreatedOn = proposal.CreatedOn,
                UrlPhoto = proposal.UrlPhoto,
                Budget=proposal.Budget,
                CustomerRegistrationNumber= proposal.CustomerRegistrationNumber,
                ProjectId =proposal.ProjectId,
            };
            this.data.Proposals.Add(proposalData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Details(string proposalId)
        {
            var proposal = this.data.Proposals
                .First(t => t.Id == int.Parse(proposalId));

            return this.View(proposal);
        }
        private IEnumerable<ProposalCustomersServiceModel> GetProposalCustomers()
            => this.data
                .Customers
                .Select(c => new ProposalCustomersServiceModel
                {
                    RegistrationNumber = c.RegistrationNumber,
                    Name = c.Name
                })
            .ToList();
        
    }
    
}
