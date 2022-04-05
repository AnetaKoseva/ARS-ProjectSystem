using ARS_ProjectSystem.Models.Customers;

namespace ARS_ProjectSystem.Services.Customers
{
    public interface ICustomerService
    {
        CustomerQueryServiceModel All(string searchTerm);

        CustomerQueryServiceModel GetById(string searchTerm, string id);

        AddCustomerFormModel GetCustomerById(string id);
        public bool Edit(AddCustomerFormModel customer);
        string Add(AddCustomerFormModel customer);

        string Delete(string id);

        string GetNameById(string id);
    }
}
