namespace ARS_ProjectSystem.Models.Customers
{
    using ARS_ProjectSystem.Services.Customers;
    using System.Collections.Generic;
    public class AllCustomersQueryModel
    {
        public string SearchTerm { get; init; }
        public IEnumerable<CustomerServiceModel> Customers{get;init;}
    }
}
