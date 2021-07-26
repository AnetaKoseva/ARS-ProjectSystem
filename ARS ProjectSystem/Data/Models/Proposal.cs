namespace ARS_ProjectSystem.Data.Models
{
    using System.Collections.Generic;
    public class Proposal
    {
        public Proposal()
        {
            this.Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedOn { get; set; }
        public string UrlPhoto { get; set; }
        public double Budget { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}