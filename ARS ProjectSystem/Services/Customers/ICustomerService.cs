using ARS_ProjectSystem.Models.Customers;

namespace ARS_ProjectSystem.Services.Customers
{
    public interface ICustomerService
    {
        CustomerQueryServiceModel All(string searchTerm);

        CustomerQueryServiceModel GetById(string searchTerm, string id);
        string Add(AddCustomerFormModel customer);

        string Delete(string id);
    }
}
