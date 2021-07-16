namespace ARS_ProjectSystem.Data.Models
{
    using System.Collections.Generic;
    public class ProjectSystemUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
