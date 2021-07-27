namespace ARS_ProjectSystem.Models.Api.Projects
{
    using ARS_ProjectSystem.Models.Projects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
