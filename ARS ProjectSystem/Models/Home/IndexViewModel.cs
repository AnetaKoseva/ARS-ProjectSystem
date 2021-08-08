namespace ARS_ProjectSystem.Models.Home
{
    using ARS_ProjectSystem.Services.Projects;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public int TotalProjects { get; init; }
        public int TotalCustomers { get; init; }
        public int TotalProposals { get; init; }
        public IEnumerable<ProjectTotalServiceModel> Projects { get; init; }
    }
}
