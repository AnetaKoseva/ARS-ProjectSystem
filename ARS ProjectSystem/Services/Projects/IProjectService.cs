namespace ARS_ProjectSystem.Services.Projects
{
    using System.Collections.Generic;
    using ARS_ProjectSystem.Models;

    public interface IProjectService
    {
        ProjectQueryServiceModel All(string programm,
            string searchTerm,
            ProjectSorting sorting,
            int currentPage,
            int projectsPerPage);
        int Create(
            int id,
            string name,
            int programmId,
            string projectPhoto,
            string status,
            string startDate,
            string endDate,
            double projectRate,
            string customerRegistrationNumber);
        IEnumerable<ProjectTotalServiceModel> Total();
        bool Edit(
            int id,
            string name,
            int programmId,
            string projectPhoto,
            string status,
            string startDate,
            string endDate,
            double projectRate,
            string customerRegistrationNumber);
        ProjectServiceModel Details(int id);
        IEnumerable<ProjectServiceModel> ByUser(string userId);
        IEnumerable<string> AllProjectProgramms();
        IEnumerable<ProjectProgrammsServiceModel> GetProjectProgramms();
        IEnumerable<ProjectProposalsServiceModel> GetProjectProposals();
        IEnumerable<ProjectCustomersServiceModel> GetProjectCustomers();
        bool ProposalExists(int proposalId);
        //bool IsByUser(int projectId, int userId);
        
    }
}
