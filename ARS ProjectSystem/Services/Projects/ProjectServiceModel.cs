namespace ARS_ProjectSystem.Services.Projects
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using static Data.DataConstants.Project;

    [ExcludeFromCodeCoverage]
    public class ProjectServiceModel
    {
        public int Id { get; init; }
        [Required]
        [StringLength(MaxLength, MinimumLength = MinLength)]
        public string Name { get; init; }
        public string ProjectPhoto { get; init; }
        public int ProgrammId { get; init; }
        public string ProgrammName { get; set; }
        public string ProposalName { get; init; }
        public string StartDate { get; init; }
        public string EndDate { get; init; }
        public string Status { get; init; }
        public double ProjectRate { get; init; }
        public string CustomerRegistrationNumber { get; init; }
    }
}
