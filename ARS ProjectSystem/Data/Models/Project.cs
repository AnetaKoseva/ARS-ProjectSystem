using System.ComponentModel.DataAnnotations;

namespace ARS_ProjectSystem.Data.Models
{
    public class Project
    {
        public int Id { get; set; }
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
    }
}