namespace ARS_ProjectSystem.Models.Projects
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class ProjectsListingViewModel
    {
        public int Id { get; init; }
        [Required]
        [StringLength(ProjectNameMaxLength, MinimumLength = ProjectNameMinLength)]
        public string Name { get; init; }
        public string ProjectPhoto { get; set; }
        public string ProgrammName { get; init; }
        public string ProposalName { get; init; }
        public string StartDate { get; init; }
        public string EndDate { get; init; }
        public string Status { get; init; }
        public double ProjectRate { get; init; }

    }
}
