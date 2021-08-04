namespace ARS_ProjectSystem.Services.Projects
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface IProjectService
    {
        ProjectQueryServiceModel All(string programm,
            string searchTerm,
            ProjectSorting sorting,
            int currentPage,
            int projectsPerPage);
        IEnumerable<ProjectServiceModel> ByUser(string userId);
        IEnumerable<string> AllProjectProgramms();
        
    }
}
