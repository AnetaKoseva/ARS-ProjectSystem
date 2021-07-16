namespace ARS_ProjectSystem.Models.Departments
{
    using System.ComponentModel.DataAnnotations;
    public class AddDepartmentFormModel
    {
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}
