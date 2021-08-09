namespace ARS_ProjectSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User:IdentityUser
    {
        public string Number { get; set; }
    }
}
