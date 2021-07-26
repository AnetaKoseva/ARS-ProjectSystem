namespace ARS_ProjectSystem.Models.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public int TotalProjects { get; init; }
        public int TotalCustomers { get; init; }
        public int TotalProposals { get; init; }
        public List<ProjectIndexViewModel> Projects { get; init; }
    }
}
