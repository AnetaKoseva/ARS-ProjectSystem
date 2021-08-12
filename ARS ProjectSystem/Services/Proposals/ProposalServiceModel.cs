namespace ARS_ProjectSystem.Services.Proposals
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.ShortApplication;
    public class ProposalServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedOn { get; set; }
        public string UrlPhoto { get; set; }
        public double Budget { get; set; }
        public string CustomerRegistrationNumber { get; set; }
        public string CustomerName { get; set; }
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
    }
}
