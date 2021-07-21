namespace ARS_ProjectSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Invoice;
    public class Invoice
    {
        
        public int Id { get; init; }
        [Required]
        [MaxLength(InvoiceLength)]
        public int Number { get; set; }
        public string CreatedOn { get; set; }
        public string DueDate { get; set; }
        public string PaymentMethod { get; set; }
        [Required]
        [MaxLength(IBANLength)]
        public string IBAN { get; set; }
        public string Item { get; set; }
        public double Price { get; set; }
    }
}