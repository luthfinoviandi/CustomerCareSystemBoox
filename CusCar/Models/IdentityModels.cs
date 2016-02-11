using Microsoft.AspNet.Identity.EntityFramework;

namespace CusCar.Models
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            :base("ConnectionString")
        { 
        }
    }
}
