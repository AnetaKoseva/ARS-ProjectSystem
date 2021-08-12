namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Employees;
    using ARS_ProjectSystem.Services.Employees;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    using static WebConstants;
    public class EmployeesController:Controller
    {

        private readonly ProjectSystemDbContext data;
        private readonly IEmployeeService employees;
        public EmployeesController(ProjectSystemDbContext data, IEmployeeService employees)
        {
            this.data = data;
            this.employees = employees;
        }
        public IActionResult All()
        {
            var employees = this.data.Employees.Select(e => new AllEmployeesServiceModel
            {
                Id = e.Id,
                FirstName=e.FirstName,
                LastName=e.LastName,
                Jobtitle=e.Jobtitle,
                DepartmentName=e.DepartmentName
            }).ToList();
            if (employees != null)
            {
                return View(employees);
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public IActionResult Add()
        {
            return View(new EmployeeFormModel
            {
                Customers = this.GetEmployeeCustomers()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddEmployeeFormModel employee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var employeeData = new Employee
            {
                Id=employee.Id,
                FirstName = employee.FirstName,
                LastName=employee.LastName,
                Jobtitle=employee.Jobtitle,
                CustomerRegistrationNumber =employee.CustomerRegistrationNumber,
                DepartmentName=employee.DepartmentName,
            };
            this.data.Employees.Add(employeeData);
            this.data.SaveChanges();

            TempData[GlobalMessageKey] = $"Employee {employee.FirstName} {employee.LastName} is added succesfully!";

            return RedirectToAction("Index", "Home");
        }
        private IEnumerable<EmployeeCustomersServiceModel> GetEmployeeCustomers()
            => this.employees.GetEmployeeCustomers();
        private IEnumerable<EmployeeProjectsServiceModel> GetEmployeeProjects()
            => this.employees.GetEmployeeProjects();
        private IEnumerable<EmployeeProposalsServiceModel> GetEmployeeProposals()
            => this.employees.GetEmployeeProposals();
        [Authorize]
        public IActionResult AddToProject()
        {
            return View(new EmployeeProjectsFormModel
            {
                Projects = this.GetEmployeeProjects()
            });
            
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddToProject(AddEmployeeFormModel employee,int employeeId)
        {
            var employeeToAdd = this.data.Employees.First(e => e.Id == employeeId);
            var project = this.data.Projects.First(p => p.Id == employee.Id);
            employeeToAdd.Projects.Add(project);
            this.data.SaveChanges();

            TempData[GlobalMessageKey] = $"Employee {employee.FirstName} {employee.LastName} is added succesfully to {project.Name}!";

            return RedirectToAction(nameof(All));
        }
        [Authorize]
        public IActionResult AddToProposal()
        {
            return View(new EmployeeProposalsFormModel
            {
                Proposals = this.GetEmployeeProposals()
            });

        }
        [HttpPost]
        [Authorize]
        public IActionResult AddToProposal(AddEmployeeFormModel employee, int employeeId)
        {
            var employeeToAdd = this.data.Employees.First(e => e.Id == employeeId);
            var proposal = this.data.Proposals.First(p => p.Id == employee.Id);
            employeeToAdd.Proposals.Add(proposal);
            this.data.SaveChanges();

            TempData[GlobalMessageKey] = $"Employee {employee.FirstName} {employee.LastName} is added succesfully to {proposal.Name}!";

            return RedirectToAction(nameof(All));
        }

    }
}
