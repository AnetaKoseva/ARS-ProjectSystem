namespace ARS_ProjectSystem.Services.Employees
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class EmployeeFormModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Jobtitle { get; set; }

        public string CustomerRegistrationNumber { get; set; }

        public string CustomerName { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public IEnumerable<EmployeeCustomersServiceModel> Customers { get; set; }
    }
}
