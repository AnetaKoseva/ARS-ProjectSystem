namespace ARS_ProjectSystem.Services.Customers
{
    public interface ICustomerService
    {
        CustomerQueryServiceModel All(string searchTerm);

    }
}
