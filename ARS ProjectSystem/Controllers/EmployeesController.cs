namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Models.Employees;
    using ARS_ProjectSystem.Services.Employees;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    using static WebConstants;
    public class EmployeesController:Controller
    {
        private readonly IEmployeeService employees;

        public EmployeesController(IEmployeeService employees)
        {
            this.employees = employees;
        }

        [Authorize]
        public IActionResult All()
        {
            var employeesData = this.employees.All();

            if (employeesData != null)
            {
                return View(employeesData);
            }
            else if(employeesData==null)
            {
                return NotFound();
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
        public IActionResult Add(EmployeeFormModel employee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            this.employees.Create(employee);

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
            var employeeData=this.employees.AddToProject(employee, employeeId);

            TempData[GlobalMessageKey] = $"Employee {employeeData.FirstName} {employeeData.LastName} is added succesfully to project {employeeData.ProjectName}!";

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
            var employeeData = this.employees.AddToProposal(employee, employeeId);

            TempData[GlobalMessageKey] = $"Employee {employeeData.FirstName} {employeeData.LastName} is added succesfully to proposal {employeeData.ProposalName}!";

            return RedirectToAction(nameof(All));
        }
    }
}
