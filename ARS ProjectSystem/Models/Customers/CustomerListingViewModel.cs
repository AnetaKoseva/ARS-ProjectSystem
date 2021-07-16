namespace ARS_ProjectSystem.Models.Customers
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class CustomerListingViewModel
    {
        public int Id { get; init; }
        [Required]
        [StringLength(CustomerNameMaxLength, MinimumLength = CustomerNameMinLength)]
        public string Name { get; init; }
        public string RegistrationNumber { get; init; }
        [Required]
        public string VAT { get; init; }
        public string OwnerName { get; init; }
    }
}
