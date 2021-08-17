namespace ARS_ProjectSystem.Services.Proposals
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ProposalService : IProposalService
    {
        private readonly ProjectSystemDbContext data;

        public ProposalService(ProjectSystemDbContext data)

            => this.data = data;
        public IEnumerable<ProposalCustomersServiceModel> GetProposalCustomers()
        => this.data
                .Customers
                .Select(c => new ProposalCustomersServiceModel
                {
                    RegistrationNumber = c.RegistrationNumber,
                    Name = c.Name
                })
            .ToList();

        public IEnumerable<ProposalServiceModel> All()
        => this.data.Proposals.Select(p => new ProposalServiceModel
        {
                Id = p.Id,
                Name=p.Name,
                CustomerRegistrationNumber=p.CustomerRegistrationNumber,
                CustomerName=p.Customer.Name,
                Budget=p.Budget,
                CreatedOn=p.CreatedOn,
                FullProposalTitle=p.FullProposalTitle,
                SolutionType=p.SolutionType,
                ProjectPurpose=p.ProjectPurpose,
                ProjectAcronym=p.ProjectAcronym,
                SolutionDescribtion=p.SolutionDescribtion,
                ProblemSolve= p.ProblemSolve,
                HowProblemIsSolved=p.HowProblemIsSolved,
                FeatureName1=p.FeatureName1,
                FeatureKnowledge1=p.FeatureKnowledge1,
                FeatureTechnology1=p.FeatureTechnology1,
                FeatureName2=p.FeatureName2,
                FeatureKnowledge2=p.FeatureKnowledge2,
                FeatureTechnology2=p.FeatureTechnology2,
                Keyword1Parent=p.Keyword1Parent,
                Keyword1Child=p.Keyword1Child,
                Keyword2Parent=p.Keyword2Parent,
                Keyword2Child=p.Keyword2Child,
                Keyword3Parent=p.Keyword3Parent,
                Keyword3Child=p.Keyword3Child,
                FreeKeyword=p.FreeKeyword,
                Abstract=p.Abstract,
                Solution=p.Solution}) 
            .ToList();

        public ProposalServiceModel Details(int id)
        =>this.data.Proposals
                .Where(p => p.Id == id).Select(p=>new ProposalServiceModel 
                { 
                Id=p.Id,
                CreatedOn=p.CreatedOn,
                Name=p.Name,
                Budget=p.Budget,
                CustomerRegistrationNumber=p.CustomerRegistrationNumber,
                ProjectId = p.ProjectId.GetValueOrDefault(),
                UrlPhoto=p.UrlPhoto,
                FullProposalTitle = p.FullProposalTitle,
                SolutionType = p.SolutionType,
                ProjectPurpose = p.ProjectPurpose,
                ProjectAcronym = p.ProjectAcronym,
                SolutionDescribtion = p.SolutionDescribtion,
                ProblemSolve = p.ProblemSolve,
                HowProblemIsSolved = p.HowProblemIsSolved,
                FeatureName1 = p.FeatureName1,
                FeatureKnowledge1 = p.FeatureKnowledge1,
                FeatureTechnology1 = p.FeatureTechnology1,
                FeatureName2 = p.FeatureName2,
                FeatureKnowledge2 = p.FeatureKnowledge2,
                FeatureTechnology2 = p.FeatureTechnology2,
                Keyword1Parent = p.Keyword1Parent,
                Keyword1Child = p.Keyword1Child,
                Keyword2Parent = p.Keyword2Parent,
                Keyword2Child = p.Keyword2Child,
                Keyword3Parent = p.Keyword3Parent,
                Keyword3Child = p.Keyword3Child,
                FreeKeyword = p.FreeKeyword,
                Abstract = p.Abstract,
                Solution = p.Solution})
            .FirstOrDefault();

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
                string solution)
        {
            var proposalData = new Proposal
            {
                Id = id,
                Name = name,
                CreatedOn = createdOn,
                UrlPhoto = urlPhoto,
                Budget = budget,
                CustomerRegistrationNumber = customerRegistrationNumber,
                ProjectId = projectId,
                FullProposalTitle=fullProposalTitle,
                SolutionType=solutionType,
                ProjectPurpose=projectPurpose,
                ProjectAcronym=projectAcronym,
                SolutionDescribtion=solutionDescribtion,
                ProblemSolve= problemSolve,
                HowProblemIsSolved= howProblemIsSolved,
                FeatureName1= featureName1,
                FeatureKnowledge1= featureKnowledge1,
                FeatureTechnology1= featureTechnology1,
                FeatureName2= featureName2,
                FeatureKnowledge2= featureKnowledge2,
                FeatureTechnology2= featureTechnology2,
                Keyword1Parent= keyword1Parent,
                Keyword1Child= keyword1Child,
                Keyword2Parent= keyword2Parent,
                Keyword2Child= keyword2Child,
                Keyword3Parent= keyword3Parent,
                Keyword3Child= keyword3Child,
                FreeKeyword= freeKeyword,
                Abstract= aabstract,
                Solution= solution};
            this.data.Proposals.Add(proposalData);
            this.data.SaveChanges();

            return proposalData.Id;
        }

        public bool Edit(
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
                string solution)
        {
            var proposalData = this.data.Proposals.Find(id);

                proposalData.Id = id;
                proposalData.Name = name;
                proposalData.CreatedOn = createdOn;
                proposalData.UrlPhoto = urlPhoto;
                proposalData.Budget = budget;
                proposalData.CustomerRegistrationNumber = customerRegistrationNumber;
                proposalData.ProjectId = projectId.GetValueOrDefault();
                proposalData.FullProposalTitle = fullProposalTitle;
                proposalData.SolutionType = solutionType;
                proposalData.ProjectPurpose = projectPurpose;
                proposalData.ProjectAcronym = projectAcronym;
                proposalData.SolutionDescribtion = solutionDescribtion;
                proposalData.ProblemSolve = problemSolve;
                proposalData.HowProblemIsSolved = howProblemIsSolved;
                proposalData.FeatureName1 = featureName1;
                proposalData.FeatureKnowledge1 = featureKnowledge1;
                proposalData.FeatureTechnology1 = featureTechnology1;
                proposalData.FeatureName2 = featureName2;
                proposalData.FeatureKnowledge2 = featureKnowledge2;
                proposalData.FeatureTechnology2 = featureTechnology2;
                proposalData.Keyword1Parent = keyword1Parent;
                proposalData.Keyword1Child = keyword1Child;
                proposalData.Keyword2Parent = keyword2Parent;
                proposalData.Keyword2Child = keyword2Child;
                proposalData.Keyword3Parent = keyword3Parent;
                proposalData.Keyword3Child = keyword3Child;
                proposalData.FreeKeyword = freeKeyword;
                proposalData.Abstract = aabstract;
                proposalData.Solution = solution;

            this.data.SaveChanges();

            return true;
        }
    }
}
