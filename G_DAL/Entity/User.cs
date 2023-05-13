using Microsoft.AspNetCore.Identity;

namespace G_DAL.Entity
{
    public class User : IdentityUser<int>
    {
        public int? TeamId { get; set; }
    }
}
