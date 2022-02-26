namespace ARS_ProjectSystem.Models.Home
{
    using System.ComponentModel.DataAnnotations;

    public class ContactForm
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enetre a valid email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your mesage")]
        [StringLength(100, ErrorMessage = "Subject need to be at least{2} and no more than {1} symbols.", MinimumLength = 5)]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your message")]
        [StringLength(10000, ErrorMessage = "Message need to be at least {2} symbols.", MinimumLength = 10)]
        public string Message { get; set; }
        
    }
}
