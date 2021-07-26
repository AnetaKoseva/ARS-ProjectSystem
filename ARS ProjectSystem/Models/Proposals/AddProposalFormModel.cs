namespace ARS_ProjectSystem.Models.Proposals
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Proposal;

    public class AddProposalFormModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(NameMaxLength,MinimumLength =NameMinLength)]
        public string Name { get; set; }
        public string CreatedOn { get; set; }
        [Url]
        public string UrlPhoto { get; set; }
        public double Budget { get; set; }
    }
}
