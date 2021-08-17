namespace ARS_ProjectSystem.Services.Customers
{
    using System.Collections.Generic;

    public class CustomerQueryServiceModel
    {
        public IEnumerable<CustomerServiceModel> Customers { get; set; }

        public string SearchTerm { get; set; }
    }
}