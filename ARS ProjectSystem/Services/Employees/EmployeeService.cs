namespace ARS_ProjectSystem.Services.Employees
{
    using ARS_ProjectSystem.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeeService:IEmployeeService
    {
        private readonly ProjectSystemDbContext data;
        public EmployeeService(ProjectSystemDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<EmployeeCustomersServiceModel> GetEmployeeCustomers()
            => this.data
                .Customers
                .Select(c => new EmployeeCustomersServiceModel
                {
                    RegistrationNumber = c.RegistrationNumber,
                    Name = c.Name
                })
            .ToList();
        public IEnumerable<EmployeeProjectsServiceModel> GetEmployeeProjects()
            => this.data
                .Projects
                .Select(c => new EmployeeProjectsServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
            .ToList();
        public IEnumerable<EmployeeProposalsServiceModel> GetEmployeeProposals()
            => this.data
                .Proposals
                .Select(c => new EmployeeProposalsServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
            .ToList();

    }
}
