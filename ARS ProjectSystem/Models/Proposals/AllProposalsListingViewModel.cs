namespace ARS_ProjectSystem.Models.Proposals
{
    public class AllProposalsListingViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string CreatedOn { get; set; }
        public string UrlPhoto { get; init; }
        public double Budget { get; set; }
        public string CustomerRegistrationNumber { get; set; }
        public string CustomerName { get; set; }
        public int? ProjectId { get; set; }
    }
}
