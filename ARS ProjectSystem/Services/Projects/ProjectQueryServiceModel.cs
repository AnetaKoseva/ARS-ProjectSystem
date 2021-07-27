namespace ARS_ProjectSystem.Services.Projects
{
    using System.Collections.Generic;

    public class ProjectQueryServiceModel
    {
        public int CurrentPage { get; init; }
        public int ProjectsPerPage { get; init; }
        public int TotalProjects { get; set; }
        public IEnumerable<ProjectServiceModel> Projects { get; init; }
    }
}
