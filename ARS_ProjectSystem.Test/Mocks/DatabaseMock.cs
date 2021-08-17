namespace ARS_ProjectSystem.Test.Mocks
{
    using ARS_ProjectSystem.Data;
    using Microsoft.EntityFrameworkCore;
    using System;

    public static class DatabaseMock
    {
        public static ProjectSystemDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<ProjectSystemDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
                return new ProjectSystemDbContext(dbContextOptions);
            }
        }
    }
}
