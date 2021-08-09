namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Models.Proposals;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using ARS_ProjectSystem.Services.Proposals;
    using ARS_ProjectSystem.Infrastructure;
    using AutoMapper;

    public class ProposalsController : Controller
    {
        private readonly IProposalService proposals;
        private readonly IMapper mapper;
        public ProposalsController(IProposalService proposals, IMapper mapper)
        {
            this.proposals = proposals;
            this.mapper = mapper;
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

            return View(new ProposalFormModel
            {
                Customers = this.GetProposalCustomers()
            });
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(ProposalFormModel proposal)
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
                proposal.ProjectId.GetValueOrDefault());

            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public IActionResult Details(int proposalId)
        {
            var proposal = this.proposals.Details(proposalId);

            return this.View(proposal);
        }
        private IEnumerable<ProposalCustomersServiceModel> GetProposalCustomers()
            => this.proposals.GetProposalCustomers();
        [Authorize]
        public IActionResult Edit(int id)
        {
            var proposal = this.proposals.Details(id);
            var proposalForm = this.mapper.Map<ProposalFormModel>(proposal);
            proposalForm.Customers = this.proposals.GetProposalCustomers();
            return View(proposalForm);
            //return View(new ProposalFormModel
            //{
            //    Id = proposal.Id,
            //    Name = proposal.Name,
            //    CreatedOn = proposal.CreatedOn,
            //    UrlPhoto = proposal.UrlPhoto,
            //    Budget = proposal.Budget,
            //    CustomerRegistrationNumber = proposal.CustomerRegistrationNumber,
            //    ProjectId = proposal.ProjectId.GetValueOrDefault(),
            //    Customers = this.proposals.GetProposalCustomers(),

            //});

        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Edit(int id, ProposalFormModel proposal)
        {
            
            var proposalIsEdited = this.proposals.Edit(
                proposal.Id,
                proposal.Name,
                proposal.CreatedOn,
                proposal.UrlPhoto,
                proposal.Budget,
                proposal.CustomerRegistrationNumber,
                proposal.ProjectId.GetValueOrDefault()
                );
            if (!proposalIsEdited || !User.IsAdmin())
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(All));

        }
    }
}
