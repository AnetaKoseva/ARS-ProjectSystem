namespace ARS_ProjectSystem.Models.Proposals
{
    using ARS_ProjectSystem.Services.Proposals;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Proposal;

    public class ProposalFormModel
    {
        public int Id { get; init; }

        [Required]
        [StringLength(NameMaxLength,MinimumLength =NameMinLength)]
        public string Name { get; init; }

        public string CreatedOn { get; set; }

        [Url]
        [Required]
        public string UrlPhoto { get; set; }

        [Required]
        public double Budget { get; set; }

        public string CustomerRegistrationNumber { get; set; }

        public int? ProjectId { get; set; }

        public string FullProposalTitle { get; init; }

        public string SolutionType { get; init; }

        public string ProjectPurpose { get; init; }

        [MaxLength(MaxCharacters)]
        public string ProjectAcronym { get; init; }

        [MaxLength(MaxCharacters)]
        public string SolutionDescribtion { get; init; }

        [MaxLength(MaxCharacters)]
        public string ProblemSolve { get; init; }

        public string HowProblemIsSolved { get; init; }

        [MaxLength(MaxFeatureLength)]
        public string FeatureName1 { get; init; }

        [MaxLength(MaxFeatureKnowleadgeOrTechnologyLength)]
        public string FeatureKnowledge1 { get; init; }

        [MaxLength(MaxFeatureKnowleadgeOrTechnologyLength)]
        public string FeatureTechnology1 { get; init; }

        [MaxLength(MaxFeatureLength)]
        public string FeatureName2 { get; init; }

        [MaxLength(MaxFeatureKnowleadgeOrTechnologyLength)]
        public string FeatureKnowledge2 { get; init; }

        [MaxLength(MaxFeatureKnowleadgeOrTechnologyLength)]
        public string FeatureTechnology2 { get; init; }

        public string Keyword1Parent { get; init; }

        public string Keyword1Child { get; init; }

        public string Keyword2Parent { get; init; }

        public string Keyword2Child { get; init; }

        public string Keyword3Parent { get; init; }

        public string Keyword3Child { get; init; }

        public string FreeKeyword { get; init; }


        [MaxLength(MaxCharacters)]
        public string Abstract { get; init; }

        public string Solution { get; init; }

        public IEnumerable<ProposalCustomersServiceModel> Customers { get; set; }
        public IEnumerable<ProposalProjectServiceModel> AllProjects { get; set; }
    }
}
