namespace ARS_ProjectSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using static DataConstants.Invoice;

    [ExcludeFromCodeCoverage]
    public class Invoice
    {
        public int Id { get; init; }

        [MaxLength(InvoiceLength)]
        public string Number { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime DueDate { get; set; }

        public string Item { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public double Total { get; set; }

        public string CustomerRegistrationNumber { get; set; }

        public string CustomerVAT { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerTown { get; set; }

        public string CustomerCountry { get; set; }

        public string CustomerOwnerName { get; set; }

        public Customer Customer { get; set; }
    }
}