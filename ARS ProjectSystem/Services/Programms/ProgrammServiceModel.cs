namespace ARS_ProjectSystem.Services.Programms
{
    using System.ComponentModel.DataAnnotations;

    public class ProgrammServiceModel
    {
        public int Id { get; set; }

        [Required]
        public string ProgrammName { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        public string Description { get; set; }
    }
}