﻿namespace ARS_ProjectSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Customer;
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
        public IEnumerable<User> Users { get; set; } = new List<User>();
        public IEnumerable<Project> Projects { get; set; } = new List<Project>();
        public IEnumerable<Proposal> Proposals { get; set; } = new List<Proposal>();
        public IEnumerable<Invoice> Invoices { get; set; } = new List<Invoice>();
        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
        
    }
}
