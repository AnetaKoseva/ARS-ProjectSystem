namespace ARS_ProjectSystem.Services.Employees
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class EmployeeProjectToAddModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProjectName { get; set; }
    }
}
