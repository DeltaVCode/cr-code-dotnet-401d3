using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models.Identity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public static readonly string Administrator = nameof(Administrator);
        public static readonly string Customer = nameof(Customer);
    }
}
