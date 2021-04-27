using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Identity
{
    public class RegisterData
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
