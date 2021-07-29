namespace ARS_ProjectSystem.Services.Projects
{
    using ARS_ProjectSystem.Models;
    using System.Collections.Generic;

    public interface IProjectService
    {
        ProjectQueryServiceModel All(string programm,
            string searchTerm,
            ProjectSorting sorting,
            int currentPage,
            int projectsPerPage);
        IEnumerable<string> AllProjectProgramms();
    }
}
