namespace ARS_ProjectSystem.Data.Models
{
    using System.Collections.Generic;

    public class Proposal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedOn { get; set; }
        public string UrlPhoto { get; set; }
        public double Budget { get; set; }
        public string CustomerRegistrationNumber { get; set; }
        public Customer Customer { get; set; }
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}