using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWeb.Models.Api;
using DemoWeb.Models.Identity;
using DemoWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterData data)
        {
            var user = await userService.Register(data, this.ModelState);
            if (!ModelState.IsValid)
            {
                // Replicates normal validation error response
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            return Ok(user);
        }
    }
}
