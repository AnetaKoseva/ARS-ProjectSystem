namespace ARS_ProjectSystem.Models.Projects
{
    using ARS_ProjectSystem.Services.Projects;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Project;
    public class ProjectFormModel
    {
        public int Id { get; init; }

        [Required]
        [StringLength(MaxLength, MinimumLength = MinLength)]

        public string Name { get; set; }

        [Required]
        public string ProjectPhoto { get; init; }

        public int ProgrammId { get; init; }

        public int? ProposalId { get; init; }

        public string CustomerRegistrationNumber { get; set; }

        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }

        [Required]
        public string Status { get; set; }

        public double ProjectRate { get; set; }

        public IEnumerable<ProjectCustomersServiceModel> Customers { get; set; }

        public IEnumerable<ProjectProposalsServiceModel> Proposals { get; set; }

        public IEnumerable<ProjectProgrammsServiceModel> Programms { get; set; }
    }
}
