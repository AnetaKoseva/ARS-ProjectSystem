namespace ARS_ProjectSystem.Models.Api.Projects
{
    using System.Collections.Generic;
    public class AllProjectsApiResponseModel
    {
        public int CurrentPage { get; init; }
        public int ProjectsPerPage { get; init; }
        public int TotalProjects { get; set; }
        public IEnumerable<ProjectResponseModel> Projects { get; init; }
    }
}
