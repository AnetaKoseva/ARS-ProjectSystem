namespace ARS_ProjectSystem.Services.Employees
{
    using ARS_ProjectSystem.Models.Employees;
    using System.Collections.Generic;

    public interface IEmployeeService
    {
        IEnumerable< AllEmployeesServiceModel> All();
        int Create(EmployeeFormModel employee);

        EmployeeProjectToAddModel AddToProject(AddEmployeeFormModel employee, int employeeId);

        EmployeeProposalToAddModel AddToProposal(AddEmployeeFormModel employee, int employeeId);

        IEnumerable<EmployeeCustomersServiceModel> GetEmployeeCustomers();

        IEnumerable<EmployeeProjectsServiceModel> GetEmployeeProjects();

        IEnumerable<EmployeeProposalsServiceModel> GetEmployeeProposals();
    }
}
