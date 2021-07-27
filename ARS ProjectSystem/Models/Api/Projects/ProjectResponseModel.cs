namespace ARS_ProjectSystem.Models.Api.Projects
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Project;

    public class ProjectResponseModel
    {
        public int Id { get; init; }
        [Required]
        [StringLength(MaxLength, MinimumLength = MinLength)]
        public string Name { get; init; }
        public string ProjectPhoto { get; init; }
        public string ProgrammName { get; init; }
        public string ProposalName { get; init; }
        public string StartDate { get; init; }
        public string EndDate { get; init; }
        public string Status { get; init; }
        public double ProjectRate { get; init; }

    }
}
