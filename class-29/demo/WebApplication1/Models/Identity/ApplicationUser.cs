using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        [StringLength(250)]
        public string ProfileImageUrl { get; set; }
    }
}
