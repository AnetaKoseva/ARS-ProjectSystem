namespace ARS_ProjectSystem.Models.Api.Customers
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Customer;
    public class CustomerResponseModel
    {
        public int Id { get; init; }
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; init; }
        public string RegistrationNumber { get; init; }
        [Required]
        public string VAT { get; init; }
        public string OwnerName { get; init; }
    }
}
