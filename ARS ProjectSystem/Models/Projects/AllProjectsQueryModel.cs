namespace ARS_ProjectSystem.Models.Projects
{

    using System.Collections.Generic;
    public class AllProjectsQueryModel
    {
        public const int ProjectsPerPage = 3;
        public string Programm { get; init; }
        public string SearchTerm { get; init; }
        public ProjectSorting Sorting { get; init; }
        public int CurrentPage { get; set; } = 1;
        public int TotalProjects { get; set; }
        public IEnumerable<string> Programms { get; set; }
        public IEnumerable<ProjectsListingViewModel> Projects{get;set;}

    }
}
