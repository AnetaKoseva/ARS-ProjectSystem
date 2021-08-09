namespace ARS_ProjectSystem.Services.Proposals
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Proposals;
    using System.Collections.Generic;
    using System.Linq;

    public class ProposalService : IProposalService
    {
        private readonly ProjectSystemDbContext data;
        public ProposalService(ProjectSystemDbContext data)
            => this.data = data;
        public IEnumerable<ProposalCustomersServiceModel> GetProposalCustomers()
        => this.data
                .Customers
                .Select(c => new ProposalCustomersServiceModel
                {
                    RegistrationNumber = c.RegistrationNumber,
                    Name = c.Name
                })
            .ToList();
        public IEnumerable<AllProposalsListingViewModel> All()
        => this.data.Proposals.Select(p => new AllProposalsListingViewModel
            {
                Id = p.Id,
                Name=p.Name,
                CustomerRegistrationNumber=p.CustomerRegistrationNumber,
                CustomerName=p.Customer.Name,
                Budget=p.Budget,
                CreatedOn=p.CreatedOn,
            }).ToList();

        public ProposalServiceModel Details(int id)
        =>this.data.Proposals
                .Where(p => p.Id == id).Select(p=>new ProposalServiceModel 
                { 
                    Id=p.Id,
                    CreatedOn=p.CreatedOn,
                 Name=p.Name,
                 Budget=p.Budget,
                 CustomerRegistrationNumber=p.CustomerRegistrationNumber,
                 ProjectId = p.ProjectId.GetValueOrDefault(),
                 UrlPhoto=p.UrlPhoto,
                }).FirstOrDefault();
        public int Create(
                int id,
                string name,
                string createdOn,
                string urlPhoto,
                double budget,
                string customerRegistrationNumber,
                int? projectId)
        {
            var proposalData = new Proposal
            {
                Id = id,
                Name = name,
                CreatedOn = createdOn,
                UrlPhoto = urlPhoto,
                Budget = budget,
                CustomerRegistrationNumber = customerRegistrationNumber,
                ProjectId = projectId,
            };
            this.data.Proposals.Add(proposalData);
            this.data.SaveChanges();

            return proposalData.Id;
        }

        public bool Edit(int id, string name, string createdOn, string urlPhoto, double budget, string customerRegistrationNumber, int? projectId)
        {
            

            var proposalData = this.data.Proposals.Find(id);
            //if you can edit the proposal
            //if()
            //{
            //    return false;
            //}
            proposalData.Id = id;
            proposalData.Name = name;
            proposalData.CreatedOn = createdOn;
            proposalData.UrlPhoto = urlPhoto;
            proposalData.Budget = budget;
            proposalData.CustomerRegistrationNumber = customerRegistrationNumber;
            proposalData.ProjectId = projectId.GetValueOrDefault();

            this.data.SaveChanges();
            return true;
        }
    }
}
