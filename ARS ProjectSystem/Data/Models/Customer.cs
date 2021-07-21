namespace ARS_ProjectSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Customer;
    public class Customer
    {
        public Customer()
        {
            this.Employees = new HashSet<Employee>();
            this.Invoices = new HashSet<Invoice>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        [Required]
        public string VAT { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string Url { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public string Country { get; set; }
        public int ProjectSystemCustomerId { get; init; }
        public ProjectSystemUser ProjectSystemUser { get; init; }

        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Employee> Employees { get; set; }
        
    }
}
