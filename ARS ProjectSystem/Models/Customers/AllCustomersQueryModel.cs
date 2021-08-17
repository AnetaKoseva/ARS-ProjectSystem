namespace ARS_ProjectSystem.Models.Customers
{
    using ARS_ProjectSystem.Services.Customers;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class AllCustomersQueryModel
    {
        public string SearchTerm { get; init; }

        public IEnumerable<CustomerServiceModel> Customers{get;set;}
    }
}
