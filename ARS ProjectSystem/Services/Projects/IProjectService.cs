namespace ARS_ProjectSystem.Services.Projects
{
    using System.Collections.Generic;
    using ARS_ProjectSystem.Models;
    using ARS_ProjectSystem.Models.Projects;

    public interface IProjectService
    {
        ProjectQueryServiceModel All(string programm,
            string searchTerm,
            ProjectSorting sorting,
            int currentPage,
            int projectsPerPage);

        int Create(ProjectFormModel project);

        IEnumerable<ProjectTotalServiceModel> Total();

        bool Edit(ProjectFormModel project);

        ProjectServiceModel Details(int id);

        IEnumerable<string> AllProjectProgramms();

        IEnumerable<ProjectProposal> AllProjects();

        IEnumerable<ProjectProgrammsServiceModel> GetProjectProgramms();

        IEnumerable<ProjectProposalsServiceModel> GetProjectProposals();

        IEnumerable<ProjectCustomersServiceModel> GetProjectCustomers();

        bool ProposalExists(int proposalId);
    }
}
