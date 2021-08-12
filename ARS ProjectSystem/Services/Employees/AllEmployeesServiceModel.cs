namespace ARS_ProjectSystem.Services.Employees
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AllEmployeesServiceModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Jobtitle { get; set; }
        public string CustomerRegistrationNumber { get; set; }
        public string CustomerName { get; set; }
        public string DepartmentName { get; set; }
    }
}
