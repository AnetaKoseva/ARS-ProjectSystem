namespace ARS_ProjectSystem.Services.Customers
{
    using ARS_ProjectSystem.Data;
    using System.Linq;

    public class CustomerService:ICustomerService
    {
        private readonly ProjectSystemDbContext data;
        public CustomerService(ProjectSystemDbContext data)
        {   
            this.data = data;
        }

        public CustomerQueryServiceModel All(string searchTerm)
        {

            var customerQuery = this.data.Customers.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                customerQuery = customerQuery.Where(c =>
                    c.Name.ToLower().Contains(searchTerm.ToLower())
                    || c.RegistrationNumber.ToLower().Contains(searchTerm.ToLower())
                    || c.OwnerName.ToLower().Contains(searchTerm.ToLower())
                    || c.VAT.ToLower().Contains(searchTerm.ToLower()));
            }
            var customers = customerQuery
                .OrderBy(c => c.Name)
                .Select(c => new CustomerServiceModel
                {
                    Name = c.Name,
                    RegistrationNumber = c.RegistrationNumber,
                    VAT = c.VAT,
                    OwnerName = c.OwnerName
                })
                .ToList();
            return new CustomerQueryServiceModel
            {
                Customers = customers,
                SearchTerm = searchTerm
            };
        }
    }
}
