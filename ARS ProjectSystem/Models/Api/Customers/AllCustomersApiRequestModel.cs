namespace ARS_ProjectSystem.Models.Api.Customers
{
    using ARS_ProjectSystem.Services.Customers;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class AllCustomersApiRequestModel
    {
        public string SearchTerm { get; init; }
        public IEnumerable<CustomerServiceModel> Customers { get; init; }
    }
}