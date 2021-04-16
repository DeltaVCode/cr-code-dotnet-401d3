using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeb.Models.Api
{
    /// <summary>
    /// Represents public interface for anyone who has registered or asked for info about the current user.
    /// </summary>
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
