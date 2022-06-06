using Microsoft.AspNetCore.Identity;

namespace liftoffHealthCare.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
