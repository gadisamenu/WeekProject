using Microsoft.AspNetCore.Identity;
namespace Domain
{
    public class User : IdentityUser
    {
        public string Password { get; set; }
        public string FullName { get; set; }
    }

}