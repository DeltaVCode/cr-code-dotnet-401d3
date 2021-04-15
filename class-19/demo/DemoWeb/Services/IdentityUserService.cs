using System;
using System.Threading.Tasks;
using DemoWeb.Models.Api;
using DemoWeb.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DemoWeb.Services
{
    public class IdentityUserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtTokenService tokenService;

        public IdentityUserService(UserManager<ApplicationUser> userManager, JwtTokenService tokenService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        public async Task<UserDto> Authenticate(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);

            if (await userManager.CheckPasswordAsync(user, password))
            {
                return await GetUserDtoAsync(user);
            }

            if (user != null)
                await userManager.AccessFailedAsync(user);

            return null;
        }

        public async Task<UserDto> Register(RegisterData data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
                // PasswordHash = data.Password, // NO
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                return await GetUserDtoAsync(user);
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }

        private async Task<UserDto> GetUserDtoAsync(ApplicationUser user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await tokenService.GetToken(user, TimeSpan.FromMinutes(5)),
            };
        }
    }
}
