namespace ARS_ProjectSystem.Test.Controllers
{
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Customers;
    using ARS_ProjectSystem.Services.Employees;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class EmployeesControllerTestWithInmemory
    {
        [Fact]
        public void GetAlEmployeeShouldReturnAllEmployeesIfFound()
        {
            var employee = new Employee
            {
                  Id=1,
                   FirstName="Aneta"
            };
            var optionsBuilder = new DbContextOptionsBuilder<ProjectSystemDbContext>()
                .UseInMemoryDatabase("test");
            var dbContext = new ProjectSystemDbContext(optionsBuilder.Options);
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();

            var employees = new EmployeeService(dbContext);
             var controller = new EmployeesController( employees);
            var result = controller.All();
            
            Assert.NotNull(result);
        }
       
    }
}
