namespace ARS_ProjectSystem.Services.Employees
{
    using System.Collections.Generic;

    public interface IEmployeeService
    {
        IEnumerable<EmployeeCustomersServiceModel> GetEmployeeCustomers();
        IEnumerable<EmployeeProjectsServiceModel> GetEmployeeProjects();
        IEnumerable<EmployeeProposalsServiceModel> GetEmployeeProposals();
    }
}
