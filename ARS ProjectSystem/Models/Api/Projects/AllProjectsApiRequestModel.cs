namespace ARS_ProjectSystem.Models.Api.Projects
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class AllProjectsApiRequestModel
    {
        public  int ProjectsPerPage { get; init; } = 3;

        public string Programm { get; init; }

        public string SearchTerm { get; init; }

        public ProjectSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalProjects { get; set; }
    }
}
