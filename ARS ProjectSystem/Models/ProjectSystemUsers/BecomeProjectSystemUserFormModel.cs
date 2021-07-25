namespace ARS_ProjectSystem.Models.ProjectSystemUsers
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.ProjectSystemUser;
    public class BecomeProjectSystemUserFormModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(NameMaxLength,MinimumLength=NameMinLength)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(ValidatePhoneNumber,
            ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }
    }
}
