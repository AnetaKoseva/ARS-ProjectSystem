namespace ARS_ProjectSystem.Services.Contracts
{
    using ARS_ProjectSystem.Models.Contracts;
    using System.Collections.Generic;

    public interface IContractService
    {
        IEnumerable<ContractServiceModel> All();

        IEnumerable<ContractServiceModel> AllCustomerContracts(string id);

        ContractServiceModel Details(int id);

        ContractServiceModel Add(int id);

        int Create(ContractFormModel contract, string id);

        bool Edit(ContractFormModel contract);

        int Delete(int id);
    }
}
