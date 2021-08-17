namespace ARS_ProjectSystem.Models.Programms
{
    using System.ComponentModel.DataAnnotations;

    public class AddProgrammFormModel
    {
        public int Id { get; init; }

        [Required]
        public string ProgrammName { get; init; }

        [Required]
        [Url]
        public string Url { get; init; }

        public string Description { get; init; }
    }
}
