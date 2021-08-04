namespace ARS_ProjectSystem.Services.Proposals
{
    using ARS_ProjectSystem.Data;
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

    }
}
