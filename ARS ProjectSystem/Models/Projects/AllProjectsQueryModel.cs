namespace ARS_ProjectSystem.Models.Projects
{

    using System.Collections.Generic;
    public class AllProjectsQueryModel
    {
        public IEnumerable<string> Programms { get; init; }
        public string SearchTerm { get; init; }
        public ProjectSorting Sorting { get; init; }
        public IEnumerable<ProjectsListingViewModel> Projects{get;init;}

    }
}
