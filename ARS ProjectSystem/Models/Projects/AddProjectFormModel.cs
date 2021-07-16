namespace ARS_ProjectSystem.Models.Projects
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class AddProjectFormModel
    {
        public int Id { get; init; }
        [Required]
        [StringLength(ProjectNameMaxLength, MinimumLength = ProjectNameMinLength)]
        public string Name { get; init; }
        public string ProjectPhoto { get; set; }
        public int ProgrammId { get; init; }
        public int ProposalId { get; init; }
        public string StartDate { get; init; }
        public string EndDate { get; init; }
        public string Status { get; set; }
        public double ProjectRate { get; set; }
        public IEnumerable<ProjectProposalsViewModel> Proposals { get; set; }
        public IEnumerable<ProjectProgrammsViewModel> Programms { get; set; }
    }
}
