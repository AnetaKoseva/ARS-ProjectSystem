namespace ARS_ProjectSystem.Models.Projects
{
    using ARS_ProjectSystem.Services.Projects;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class AllProjectsQueryModel
    {
        public const int ProjectsPerPage = 3;

        public string Programm { get; init; }

        public string SearchTerm { get; init; }

        public ProjectSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalProjects { get; set; }

        public IEnumerable<string> Programms { get; set; }

        public IEnumerable<ProjectServiceModel> Projects{get;set;}
    }
}
