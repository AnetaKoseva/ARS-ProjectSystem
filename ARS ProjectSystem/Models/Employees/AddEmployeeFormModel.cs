namespace ARS_ProjectSystem.Models.Employees
{
    using System.ComponentModel.DataAnnotations;
    public class AddEmployeeFormModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Jobtitle { get; set; }

        public string CustomerRegistrationNumber { get; set; }

        public string CustomerName{ get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int ProjectId { get; set; }

        public int ProposalId { get; set; }
    }
}