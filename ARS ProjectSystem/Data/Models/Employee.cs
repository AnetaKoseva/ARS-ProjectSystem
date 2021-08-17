namespace ARS_ProjectSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Jobtitle { get; set; }

        public string CustomerRegistrationNumber { get; set; }

        public Customer Customer { get; set; }

        public string DepartmentName { get;set; }

        public ICollection<Project> Projects { get; set; } = new List<Project>();

        public ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
    }
}