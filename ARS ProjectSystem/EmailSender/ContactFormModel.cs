namespace ARS_ProjectSystem.EmailSender
{
    using ARS_ProjectSystem.Recaptcha;
    using System.ComponentModel.DataAnnotations;

    public class ContactFormModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please entere a valid email")]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your mesage")]
        [StringLength(100, ErrorMessage = "Subject must to be at least {2} and no more than {1} symbols.", MinimumLength = 5)]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your message")]
        [StringLength(10000, ErrorMessage = "Message must to be at least {2} symbols.", MinimumLength = 10)]
        public string Message { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
