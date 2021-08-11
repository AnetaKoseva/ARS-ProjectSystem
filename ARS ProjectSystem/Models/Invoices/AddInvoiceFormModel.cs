﻿namespace ARS_ProjectSystem.Models.Invoices
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Invoice;
    public class AddInvoiceFormModel
    {
        public int Id { get; set; }
        //10symbols
        public int Number { get; set; }
        public string CreatedOn { get; set; }
        public string DueDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerRegistrationNumber { get; set; }
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
