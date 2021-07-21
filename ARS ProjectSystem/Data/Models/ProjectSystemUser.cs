namespace ARS_ProjectSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Project;

    public class ProjectSystemUser
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxLength)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(MaxLength)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserId { get; set; }
        public  IdentityUser User{ get; set; }
        public IEnumerable<Customer> Customers { get; init; } = new List<Customer>();
    }
}
