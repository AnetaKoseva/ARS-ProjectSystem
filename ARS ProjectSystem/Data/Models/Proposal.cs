namespace ARS_ProjectSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    using static Data.DataConstants.Proposal;

    [ExcludeFromCodeCoverage]
    public class Proposal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UrlPhoto { get; set; }

        public double Budget { get; set; }

        public string CustomerRegistrationNumber { get; set; }

        public Customer Customer { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public string FullProposalTitle { get; set; }

        public string SolutionType { get; set; }

        public string ProjectPurpose { get; set; }

        [MaxLength(MaxCharacters)]
        public string ProjectAcronym { get; set; }

        [MaxLength(MaxCharacters)]
        public string SolutionDescribtion { get; set; }

        [MaxLength(MaxCharacters)]
        public string ProblemSolve { get; set; }

        public string HowProblemIsSolved { get; set; }

        [MaxLength(MaxFeatureLength)]
        public string FeatureName1 { get; set; }

        [MaxLength(MaxFeatureKnowleadgeOrTechnologyLength)]
        public string FeatureKnowledge1 { get; set; }

        [MaxLength(MaxFeatureKnowleadgeOrTechnologyLength)]
        public string FeatureTechnology1 { get; set; }

        [MaxLength(MaxFeatureLength)]
        public string FeatureName2 { get; set; }

        [MaxLength(MaxFeatureKnowleadgeOrTechnologyLength)]
        public string FeatureKnowledge2 { get; set; }

        [MaxLength(MaxFeatureKnowleadgeOrTechnologyLength)]
        public string FeatureTechnology2 { get; set; }

        public string Keyword1Parent { get; set; }

        public string Keyword1Child { get; set; }

        public string Keyword2Parent { get; set; }

        public string Keyword2Child { get; set; }

        public string Keyword3Parent { get; set; }

        public string Keyword3Child { get; set; }

        public string FreeKeyword { get; set; }

        [MaxLength(MaxCharacters)]
        public string Abstract { get; set; }

        public string Solution { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}