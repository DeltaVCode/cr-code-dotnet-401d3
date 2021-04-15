using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWeb.Models.Identity;

namespace DemoWeb.Services
{
    public class JwtTokenService
    {
        public async Task<string> GetToken(ApplicationUser user, TimeSpan expiresIn)
        {
            return "token!";
        }
    }
}
