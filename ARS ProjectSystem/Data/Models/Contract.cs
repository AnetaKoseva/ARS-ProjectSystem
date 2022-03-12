namespace ARS_ProjectSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Contract
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }
        public string CustomerRegistrationNumber { get; set; }

        public string CustomerVAT { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerTown { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerUrl { get; set; }

        public string CustomerCountry { get; set; }

        public string CustomerOwnerName { get; set; }
        public string Product { get; set; }

        public double Price { get; set; }
        public double AdvancePrice { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime DueDate { get; set; }
    }
}
