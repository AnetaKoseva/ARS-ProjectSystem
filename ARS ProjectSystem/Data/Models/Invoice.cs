namespace ARS_ProjectSystem.Data.Models
{
    public class Invoice
    {
        public int Id { get; init; }
        public string CreatedOn { get; set; }
        public string DueDate { get; set; }
        public string PaymentMethod { get; set; }
        public string IBAN { get; set; }
        public string Item { get; set; }
        public double Price { get; set; }
    }
}