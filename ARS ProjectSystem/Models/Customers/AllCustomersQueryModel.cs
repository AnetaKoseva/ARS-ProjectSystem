namespace ARS_ProjectSystem.Models.Customers
{
    using System.Collections.Generic;
    public class AllCustomersQueryModel
    {
        public string SearchTerm { get; init; }
        public CustomerSorting Sorting { get; init; }
        public IEnumerable<CustomerListingViewModel> Customers{get;init;}
    }
}
