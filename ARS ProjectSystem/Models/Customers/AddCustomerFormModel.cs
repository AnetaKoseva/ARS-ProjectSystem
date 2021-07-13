namespace ARS_ProjectSystem.Models.Customers
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class AddCustomerFormModel
    {
        public int Id { get; init; }
        [Required]
        [StringLength(CustomerNameMaxLength, MinimumLength = CustomerNameMinLength)]
        public string Name { get; init; }
        public string RegistrationNumber { get; init; }
        [Required]
        public string VAT { get; init; }
        public string OwnerName { get; init; }
        public string PhoneNumber { get; init; }
        [Required]
        public string Email { get; init; }
        public string Url { get; set; }
        [Required]
        public string Address { get; init; }
        [Required]
        public string Town { get; init; }
        [Required]
        public string Country { get; init; }
    }
}
