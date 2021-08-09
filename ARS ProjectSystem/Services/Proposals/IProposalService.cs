namespace ARS_ProjectSystem.Services.Proposals
{
    using ARS_ProjectSystem.Models.Proposals;
    using System.Collections.Generic;
    public interface IProposalService
    {
        IEnumerable<ProposalCustomersServiceModel> GetProposalCustomers();
        public IEnumerable<AllProposalsListingViewModel> All();
        public ProposalServiceModel Details(int id);
        public int Create(
                int id,
                string name,
                string createdOn,
                string urlPhoto,
                double budget,
                string customerRegistrationNumber,
                int? projectId);
        bool Edit(
                int id,
                string name,
                string createdOn,
                string urlPhoto,
                double budget,
                string customerRegistrationNumber,
                int? projectId);
    }
}
