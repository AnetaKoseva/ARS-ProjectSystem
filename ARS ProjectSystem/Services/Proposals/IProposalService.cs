namespace ARS_ProjectSystem.Services.Proposals
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Proposals;
    using System.Collections.Generic;
    public interface IProposalService
    {
        IEnumerable<ProposalCustomersServiceModel> GetProposalCustomers();

        IEnumerable<ProposalProjectServiceModel> GetProposalProjects();

        IEnumerable<ProposalServiceModel> All();

        IEnumerable<ProposalServiceModel> GetById(string id);
        ProposalServiceModel Details(int id);

        int Create(ProposalFormModel proposal);
        bool Edit(ProposalFormModel proposal);
    }
}
