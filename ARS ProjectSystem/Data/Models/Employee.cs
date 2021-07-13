namespace ARS_ProjectSystem.Data.Models
{
    using System.Collections.Generic;
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Jobtitle { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}