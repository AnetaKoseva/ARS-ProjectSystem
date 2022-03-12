namespace ARS_ProjectSystem.Models.Contracts
{
    using ARS_ProjectSystem.Data.Models;
    using System;

    public class ContractFormModel
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public string Product { get; set; }

        public double Price { get; set; }

        public double AdvancePrice { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime DueDate { get; set; }
    }
}
