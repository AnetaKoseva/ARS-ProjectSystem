namespace ARS_ProjectSystem.Services.Employees
{
    using System.Diagnostics.CodeAnalysis;
    using System.Collections.Generic;

    [ExcludeFromCodeCoverage]
    public class EmployeeProposalsFormModel
    {
        public int Id { get; set; }

        public IEnumerable<EmployeeProposalsServiceModel> Proposals { get; set; }
    }
}
