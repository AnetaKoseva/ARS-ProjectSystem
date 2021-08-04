namespace ARS_ProjectSystem.Models.Home
{
    using System.ComponentModel.DataAnnotations;
    public class ProjectIndexViewModel
    {
        public int Id { get; init; }
        [Required]
        public string Name { get; init; }
        public string ProjectPhoto { get; set; }
        public string ProgrammName { get; init; }
    }
}