namespace ARS_ProjectSystem.Services.Employees
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Employees;
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeeService:IEmployeeService
    {
        private readonly ProjectSystemDbContext data;
        public EmployeeService(ProjectSystemDbContext data)
        {
            this.data = data;
        }

        public int Create(int id,
            string firstName,
            string lastName,
            string jobTitle,
            string customerRegistrationNumber,
            string departmentName)
        {
            var employeeData = new Employee
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Jobtitle = jobTitle,
                CustomerRegistrationNumber = customerRegistrationNumber,
                DepartmentName = departmentName
            };
            this.data.Employees.Add(employeeData);
            this.data.SaveChanges();

            return employeeData.Id;
        }

        public IEnumerable< AllEmployeesServiceModel> All()
        =>this.data.Employees.Select(e => new AllEmployeesServiceModel
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Jobtitle = e.Jobtitle,
                DepartmentName = e.DepartmentName
            }).ToList();
        

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

        public EmployeeProjectToAddModel AddToProject(AddEmployeeFormModel employee, int employeeId)
        {
            var employeeToAdd = this.data.Employees.First(e => e.Id == employeeId);
            var project = this.data.Projects.First(p => p.Id == employee.Id);

            employeeToAdd.Projects.Add(project);

            this.data.SaveChanges();
            return new EmployeeProjectToAddModel { FirstName = employeeToAdd.FirstName, LastName = employeeToAdd.LastName, ProjectName = project.Name };
        }

        public EmployeeProposalToAddModel AddToProposal(AddEmployeeFormModel employee, int employeeId)
        {
            var employeeToAdd = this.data.Employees.First(e => e.Id == employeeId);
            var proposal = this.data.Proposals.First(p => p.Id == employee.Id);

            employeeToAdd.Proposals.Add(proposal);

            this.data.SaveChanges();

            return new EmployeeProposalToAddModel { FirstName = employeeToAdd.FirstName, LastName = employeeToAdd.LastName, ProposalName = proposal.Name };
        }
    }
}
