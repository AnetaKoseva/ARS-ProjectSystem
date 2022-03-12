namespace ARS_ProjectSystem.Services.Contracts
{
    using System;

    public class ContractServiceModel
    {
        public int Id { get; set; }

        public CustomerContractServiseModel Customer { get; set; }

        public string Product { get; set; }

        public double AdvancePrice { get; set; }

        public double Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime DueDate { get; set; }
    }
}
