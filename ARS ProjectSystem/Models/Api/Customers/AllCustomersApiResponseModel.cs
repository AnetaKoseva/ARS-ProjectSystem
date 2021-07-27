namespace ARS_ProjectSystem.Models.Api.Customers
{
    using System.Collections.Generic;

    public class AllCustomersApiResponseModel
    {
        public string SearchTerm { get; init; }
        public IEnumerable<CustomerResponseModel> Customers { get; init; }
    }
}
