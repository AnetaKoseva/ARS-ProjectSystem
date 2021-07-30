namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Departments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class DepartmentsController:Controller
    {
        private readonly ProjectSystemDbContext data;
        public DepartmentsController(ProjectSystemDbContext data)
            => this.data = data;
        [Authorize]
        public IActionResult Add() => View();
        public IActionResult All()
        {
            var departments = this.data.Departments.ToList();
            if(departments!=null)
            {
                return View(departments);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(AddDepartmentFormModel department)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var departmentData = new Department
            {
                DepartmentName = department.DepartmentName,
                
            };
            this.data.Departments.Add(departmentData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
