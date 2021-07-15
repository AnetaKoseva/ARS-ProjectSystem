namespace ARS_ProjectSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}