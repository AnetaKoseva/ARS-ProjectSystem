namespace ARS_ProjectSystem.Models.Proposals
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Proposal;

    public class AddProposalFormModel
    {
        public int Id { get; init; }
        [Required]
        [StringLength(NameMaxLength,MinimumLength =NameMinLength)]
        public string Name { get; init; }
        public string CreatedOn { get; set; }
        [Url]
        public string UrlPhoto { get; set; }
        public double Budget { get; set; }
        public string CustomerRegistrationNumber { get; set; }
        public int? ProjectId { get; set; }
        public IEnumerable<ProposalCustomersViewModel> Customers { get; set; }
        public IEnumerable<ProposalProjectsViewModel> Projects { get; set; }
    }
}
