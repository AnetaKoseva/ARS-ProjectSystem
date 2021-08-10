namespace ARS_ProjectSystem.Services.Proposals
{
    using ARS_ProjectSystem.Models.Proposals;
    using System.Collections.Generic;
    public interface IProposalService
    {
        IEnumerable<ProposalCustomersServiceModel> GetProposalCustomers();
        public IEnumerable<AllProposalsListingViewModel> All();
        public ProposalServiceModel Details(int id);
        public int Create(
                int id,
                string name,
                string createdOn,
                string urlPhoto,
                double budget,
                string customerRegistrationNumber,
                int? projectId,
                string fullProposalTitle,
                string solutionType,
                string projectPurpose,
                string projectAcronym,
                string solutionDescribtion,
                string problemSolve,
                string howProblemIsSolved,
                string featureName1,
                string featureKnowledge1,
                string featureTechnology1,
                string featureName2,
                string featureKnowledge2,
                string featureTechnology2,
                string keyword1Parent,
                string keyword1Child,
                string keyword2Parent,
                string keyword2Child,
                string keyword3Parent,
                string keyword3Child,
                string freeKeyword,
                string aabstract,
                string solution);
        bool Edit(
                int id,
                string name,
                string createdOn,
                string urlPhoto,
                double budget,
                string customerRegistrationNumber,
                int? projectId,
                string fullProposalTitle,
                string solutionType,
                string projectPurpose,
                string projectAcronym,
                string solutionDescribtion,
                string problemSolve,
                string howProblemIsSolved,
                string featureName1,
                string featureKnowledge1,
                string featureTechnology1,
                string featureName2,
                string featureKnowledge2,
                string featureTechnology2,
                string keyword1Parent,
                string keyword1Child,
                string keyword2Parent,
                string keyword2Child,
                string keyword3Parent,
                string keyword3Child,
                string freeKeyword,
                string aabstract,
                string solution);
    }
}
