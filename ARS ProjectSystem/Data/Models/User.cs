namespace ARS_ProjectSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.User;

    public class User:IdentityUser
    {
        public string Number { get; set; }

    }
}
