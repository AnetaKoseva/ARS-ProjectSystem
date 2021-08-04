namespace ARS_ProjectSystem.Services.Proposals
{
    using System.Collections.Generic;
    public interface IProposalService
    {
        IEnumerable<ProposalCustomersServiceModel> GetProposalCustomers();
    }
}
