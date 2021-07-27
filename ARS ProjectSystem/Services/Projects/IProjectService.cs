namespace ARS_ProjectSystem.Services.Projects
{
    using ARS_ProjectSystem.Models;
    public interface IProjectService
    {
        ProjectQueryServiceModel All(string programm,
            string searchTerm,
            ProjectSorting sorting,
            int currentPage,
            int projectsPerPage);
    }
}
