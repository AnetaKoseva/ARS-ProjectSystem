using System.ComponentModel.DataAnnotations;

namespace ARS_ProjectSystem.Services.Contracts
{
    public class CustomerContractServiseModel
    {
        public string RegistrationNumber { get; init; }

        [Required]
        public string Name { get; init; }

        [Required]
        public string VAT { get; init; }

        public string OwnerName { get; init; }

        [Phone]
        public string PhoneNumber { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Url]
        public string Url { get; set; }

        [Required]
        public string Address { get; init; }

        [Required]
        public string Town { get; init; }

        [Required]
        public string Country { get; init; }
    }
}