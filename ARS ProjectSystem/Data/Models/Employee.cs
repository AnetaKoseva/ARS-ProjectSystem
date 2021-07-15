namespace ARS_ProjectSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Jobtitle { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}