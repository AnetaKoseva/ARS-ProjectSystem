namespace ARS_ProjectSystem.Services.Proposals
{
    using ARS_ProjectSystem.Models.Proposals;
    using System.Collections.Generic;
    public interface IProposalService
    {
        IEnumerable<ProposalCustomersServiceModel> GetProposalCustomers();

        public IEnumerable<ProposalServiceModel> All();

        public ProposalServiceModel Details(int id);

        public int Create(ProposalFormModel proposal);
        bool Edit(ProposalFormModel proposal);
    }
}
