namespace ARS_ProjectSystem.Services.Customers
{
    public interface ICustomerService
    {
        CustomerQueryServiceModel All(string searchTerm);
        string Add(
            string name,
            string registrationNumber,
            string VAT,
            string ownerName,
            string phoneNumber,
            string email,
            string url,
            string address,
            string town,
            string country);
        string Delete(string id);
    }
}
