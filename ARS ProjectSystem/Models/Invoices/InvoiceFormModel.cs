namespace ARS_ProjectSystem.Models.Invoices
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class InvoiceFormModel
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime DueDate { get; set; }

        public string CustomerName { get; set; }

        public string CustomerRegistrationNumber { get; set; }

        public string CustomerVAT { get; set; }

        public string Owner { get; set; }

        public string CustomerAddress { get; set; }

        public string Town { get; set; }

        public string Country { get; set; }

        public string Item { get; set; }

        public int Quantity { get; set; }

        public string CustomerOwner { get; set; }

        public double Price { get; set; }

        public double Total { get; set; }
    }
}
