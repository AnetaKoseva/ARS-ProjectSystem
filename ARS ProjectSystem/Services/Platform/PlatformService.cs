namespace ARS_ProjectSystem.Services.Platform
{
    using ARS_ProjectSystem.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlatformService : IPlatformService
    {
        private readonly ProjectSystemDbContext data;
        public PlatformService(ProjectSystemDbContext data)
        {
            this.data = data;
        }
        public IEnumerable<PlatformCustomersServiceModel> GetPlatformCustomers()
            =>this.data
            .Customers
            .Select(c => new PlatformCustomersServiceModel
            {
                RegistrationNumber = c.RegistrationNumber,
                Name = c.Name
            })
                .ToList();
    }
}
