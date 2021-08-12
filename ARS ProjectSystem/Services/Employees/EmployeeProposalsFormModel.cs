namespace ARS_ProjectSystem.Services.Employees
{
    using System.Collections.Generic;
    public class EmployeeProposalsFormModel
    {
        public int Id { get; set; }
        public IEnumerable<EmployeeProposalsServiceModel> Proposals { get; set; }
    }
}
