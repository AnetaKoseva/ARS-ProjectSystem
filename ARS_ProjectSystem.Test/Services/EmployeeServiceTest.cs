namespace ARS_ProjectSystem.Test.Services
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Services.Employees;
    using ARS_ProjectSystem.Test.Mocks;
    using Xunit;

    public class EmployeeServiceTest
    {
        [Fact]
        public void GetEmployeeCustomersShoudReturnNotNull()
        {
            using var data = DatabaseMock.Instance;
            
            var customer=data.Customers.Add(new Customer
            {
                RegistrationNumber = "999999999",
                Name = "ARS",
            });
            var employee=data.Employees.Add(new Employee
            {
                CustomerRegistrationNumber = "999999999",
                FirstName ="Aneta"
            });
            data.SaveChanges();
            var employeeService = new EmployeeService(data);
            var result = employeeService.GetEmployeeCustomers();
            Assert.NotNull(result);
        }
        [Fact]
        public void GetEmployeeProjectsShoudReturnNotNull()
        {
            using var data = DatabaseMock.Instance;
            var customer = data.Customers.Add(new Customer
            {
                RegistrationNumber = "999999999",
                Name = "ARS",
            });
            var project = data.Projects.Add(new Project
            {
                CustomerRegistrationNumber = "999999999",
                 Name="AI4Media"
            });
            data.SaveChanges();
            var projectsService = new EmployeeService(data);
            var result = projectsService.GetEmployeeProjects();
            Assert.NotNull(result);
        }
        [Fact]
        public void GetEmployeeProposalsShoudReturnNotNull()
        {
            using var data = DatabaseMock.Instance;
            var customer = data.Customers.Add(new Customer
            {
                RegistrationNumber = "999999999",
                Name = "ARS",
            });
            var proposal = data.Proposals.Add(new Proposal
            {
                CustomerRegistrationNumber = "999999999",
                Name = "AI4Media"
            });
            data.SaveChanges();
            var proposalService = new EmployeeService(data);
            var result = proposalService.GetEmployeeProposals();
            Assert.NotNull(result);
        }
    }
}
