namespace ARS_ProjectSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using static DataConstants.Customer;

    [ExcludeFromCodeCoverage]
    public class Customer
    {
        [Key]
        public string RegistrationNumber { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

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

        public ICollection<User> Users { get; set; } = new List<User>();

        public ICollection<Project> Projects { get; set; } = new List<Project>();

        public ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();

        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
