﻿namespace ARS_ProjectSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;

    using static DataConstants.Project;

    [ExcludeFromCodeCoverage]
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string Name { get; set; }

        [Required]
        public string ProjectPhoto { get; set; }

        public Programm Programm { get; set; }

        public int ProgrammId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }

        public double ProjectRate { get; set; }

        public string CustomerRegistrationNumber { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey(nameof(Proposal))]
        public int? ProposalId { get; set; }

        public virtual Proposal Proposal { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}