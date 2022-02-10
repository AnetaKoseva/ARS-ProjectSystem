namespace ARS_ProjectSystem.Services.Employees
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class EmployeeProposalToAddModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProposalName { get; set; }
    }
}