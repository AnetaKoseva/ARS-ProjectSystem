namespace ARS_ProjectSystem.Services.Platform
{
    using System;
    using System.Collections.Generic;

    public interface IPlatformService
    {
        IEnumerable<PlatformCustomersServiceModel> GetPlatformCustomers();
    }
}
