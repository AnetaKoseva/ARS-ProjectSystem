namespace ARS_ProjectSystem.Models.Projects
{

    using System.Collections.Generic;
    public class AllProjectsQueryModel
    {
        public string Programm { get; init; }
        public string SearchTerm { get; init; }
        public ProjectSorting Sorting { get; init; }
        public IEnumerable<string> Programms { get; set; }
        public IEnumerable<ProjectsListingViewModel> Projects{get;set;}

    }
}
