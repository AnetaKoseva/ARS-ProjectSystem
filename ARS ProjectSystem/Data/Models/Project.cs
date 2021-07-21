namespace ARS_ProjectSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Project;
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxLength)]
        public string Name { get; set; }
        [Required]
        public string ProjectPhoto { get; set; }
        public Programm Programm { get; set; }
        public int ProgrammId { get; set; }
        public Proposal Proposal { get; set; }
        public int ProposalId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public double ProjectRate { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}