﻿namespace ARS_ProjectSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Jobtitle { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public IEnumerable<Project> Projects { get; set; } = new List<Project>();
        public IEnumerable<Proposal> Proposals { get; set; } = new List<Proposal>();
    }
}