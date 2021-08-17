namespace ARS_ProjectSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Programm
    {
        public int Id { get; set; }

        public string ProgrammName { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        public string Description { get; set; }

        public ICollection<Project> Projects { get; set; } = new List<Project>();

    }
}