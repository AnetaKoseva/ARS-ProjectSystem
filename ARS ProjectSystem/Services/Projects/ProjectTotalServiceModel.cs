namespace ARS_ProjectSystem.Services.Projects
{
    using System.ComponentModel.DataAnnotations;
    public class ProjectTotalServiceModel
    {
        public int Id { get; init; }
        [Required]
        public string Name { get; init; }
        public string ProjectPhoto { get; set; }
        public string ProgrammName { get; init; }
    }
}