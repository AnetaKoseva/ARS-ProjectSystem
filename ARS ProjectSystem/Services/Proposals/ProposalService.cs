namespace ARS_ProjectSystem.Services.Proposals
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Proposals;
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

        public int Create(ProposalFormModel proposal)
        {
            var proposalData = new Proposal
            {
                Id = proposal.Id,
                Name = proposal.Name,
                CreatedOn = proposal.CreatedOn,
                UrlPhoto = proposal.UrlPhoto,
                Budget = proposal.Budget,
                CustomerRegistrationNumber = proposal.CustomerRegistrationNumber,
                ProjectId = proposal.ProjectId,
                FullProposalTitle= proposal.FullProposalTitle,
                SolutionType= proposal.SolutionType,
                ProjectPurpose= proposal.ProjectPurpose,
                ProjectAcronym= proposal.ProjectAcronym,
                SolutionDescribtion= proposal.SolutionDescribtion,
                ProblemSolve= proposal.ProblemSolve,
                HowProblemIsSolved= proposal.HowProblemIsSolved,
                FeatureName1= proposal.FeatureName1,
                FeatureKnowledge1= proposal.FeatureKnowledge1,
                FeatureTechnology1= proposal.FeatureTechnology1,
                FeatureName2= proposal.FeatureName2,
                FeatureKnowledge2= proposal.FeatureKnowledge2,
                FeatureTechnology2= proposal.FeatureTechnology2,
                Keyword1Parent= proposal.Keyword1Parent,
                Keyword1Child= proposal.Keyword1Child,
                Keyword2Parent= proposal.Keyword2Parent,
                Keyword2Child= proposal.Keyword2Child,
                Keyword3Parent= proposal.Keyword3Parent,
                Keyword3Child= proposal.Keyword3Child,
                FreeKeyword= proposal.FreeKeyword,
                Abstract= proposal.Abstract,
                Solution= proposal.Solution
            };
            this.data.Proposals.Add(proposalData);
            this.data.SaveChanges();

            return proposalData.Id;
        }

        public bool Edit(ProposalFormModel proposal)
        {
            var proposalData = this.data.Proposals.Find(proposal.Id);

                proposalData.Id = proposal.Id;
                proposalData.Name = proposal.Name;
                proposalData.CreatedOn = proposal.CreatedOn;
                proposalData.UrlPhoto = proposal.UrlPhoto;
                proposalData.Budget = proposal.Budget;
                proposalData.CustomerRegistrationNumber = proposal.CustomerRegistrationNumber;
                proposalData.ProjectId = proposal.ProjectId.GetValueOrDefault();
                proposalData.FullProposalTitle = proposal.FullProposalTitle;
                proposalData.SolutionType = proposal.SolutionType;
                proposalData.ProjectPurpose = proposal.ProjectPurpose;
                proposalData.ProjectAcronym = proposal.ProjectAcronym;
                proposalData.SolutionDescribtion = proposal.SolutionDescribtion;
                proposalData.ProblemSolve = proposal.ProblemSolve;
                proposalData.HowProblemIsSolved = proposal.HowProblemIsSolved;
                proposalData.FeatureName1 = proposal.FeatureName1;
                proposalData.FeatureKnowledge1 = proposal.FeatureKnowledge1;
                proposalData.FeatureTechnology1 = proposal.FeatureTechnology1;
                proposalData.FeatureName2 = proposal.FeatureName2;
                proposalData.FeatureKnowledge2 = proposal.FeatureKnowledge2;
                proposalData.FeatureTechnology2 = proposal.FeatureTechnology2;
                proposalData.Keyword1Parent = proposal.Keyword1Parent;
                proposalData.Keyword1Child = proposal.Keyword1Child;
                proposalData.Keyword2Parent = proposal.Keyword2Parent;
                proposalData.Keyword2Child = proposal.Keyword2Child;
                proposalData.Keyword3Parent = proposal.Keyword3Parent;
                proposalData.Keyword3Child = proposal.Keyword3Child;
                proposalData.FreeKeyword = proposal.FreeKeyword;
                proposalData.Abstract = proposal.Abstract;
                proposalData.Solution = proposal.Solution;

            this.data.SaveChanges();

            return true;
        }

        public IEnumerable<ProposalServiceModel> GetById(string id)
        {
            var user = this.data.Users.FirstOrDefault(x => x.Id == id);

            var proposalData = this.data.Proposals.Where(x => x.CustomerRegistrationNumber == user.Number);
            return proposalData.Select(p => new ProposalServiceModel
            {
                Id = p.Id,
                Name = p.Name,
                CustomerRegistrationNumber = p.CustomerRegistrationNumber,
                CustomerName = p.Customer.Name,
                Budget = p.Budget,
                CreatedOn = p.CreatedOn,
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
                Solution = p.Solution
            })
            .ToList();
        }
    }
}
