using Microsoft.AspNetCore.Identity;

namespace TheActivist.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool Is_Admin { get; set; }
    }
}
