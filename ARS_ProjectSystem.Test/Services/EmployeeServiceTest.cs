namespace ARS_ProjectSystem.Test.Services
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Employees;
    using ARS_ProjectSystem.Services.Employees;
    using ARS_ProjectSystem.Test.Mocks;
    using System.Linq;
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

            var employee = data.Employees.Add(new Employee
            {
                 FirstName="Aneta"
            });

            var project = data.Projects.Add(new Project
            {
                 Name="ARS"
            });
            data.SaveChanges();

            var employeeService = new EmployeeService(data);
            var result = employeeService.GetEmployeeProjects();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetEmployeeProposalsShoudReturnNotNull()
        {
            using var data = DatabaseMock.Instance;

            var employee = data.Employees.Add(new Employee
            {
                FirstName = "Aneta"
            }); 

            var proposal = data.Proposals.Add(new Proposal
            {
                Name = "AI4Media"
            });

            data.SaveChanges();

            var employeeService = new EmployeeService(data);
            var result = employeeService.GetEmployeeProposals();

            Assert.NotNull(result);
        }

        [Fact]
        public void CreateEmployeeShoudReturnTrueData()
        {
            using var data = DatabaseMock.Instance;

            var employeeService = new EmployeeService(data);
            var employee = new EmployeeFormModel
            {
                Id = 1,
                FirstName = "Aneta",
                LastName = "Koseva",
                Jobtitle = "CEO",
                CustomerRegistrationNumber = "9999999",
                DepartmentName = "xxxx"
            };
            employeeService.Create(employee);
            var count = data.Employees.Count();

            Assert.Equal(1,count);
        }

        //addtoproject
        [Fact]
        public void AddToProposalsShoudReturnNotNull()
        {
            using var data = DatabaseMock.Instance;

            var employee = data.Employees.Add(new Employee
            {
                Id=1,
                FirstName = "Aneta",
            });

            var proposal = data.Proposals.Add(new Proposal
            {
                Name = "AI4Media"
            });

            data.SaveChanges();

            var formModel = new AddEmployeeFormModel() { Id=1, FirstName="Aneta" };
            var employeeService = new EmployeeService(data);
            var result = employeeService.AddToProposal(formModel,employee.Entity.Id);
            var count = result.FirstName;

            Assert.NotNull(result);
            Assert.Equal("Aneta", count);
        }

        [Fact]
        public void AddToProjectsShoudReturnNotNull()
        {
            using var data = DatabaseMock.Instance;

            var employee = data.Employees.Add(new Employee
            {
                Id = 1,
                FirstName = "Aneta",
            });

            var project = data.Projects.Add(new Project
            {
                Name = "AI4Media"
            });

            data.SaveChanges();

            var formModel = new AddEmployeeFormModel() { Id = 1, FirstName = "Aneta", };
            var employeeService = new EmployeeService(data);
            var result = employeeService.AddToProject(formModel, employee.Entity.Id);
            var count = result.FirstName;

            Assert.NotNull(result);
            Assert.Equal("Aneta", count);
        }
    }
}
