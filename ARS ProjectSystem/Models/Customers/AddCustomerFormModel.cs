namespace ARS_ProjectSystem.Models.Customers
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Customer;
    public class AddCustomerFormModel
    {
        public string Id { get; init; }
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; init; }
        public string RegistrationNumber { get; init; }
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
