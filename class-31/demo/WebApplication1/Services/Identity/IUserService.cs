using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.Models.Identity;

namespace WebApplication1.Services.Identity
{
    public interface IUserService
    {
        Task<ApplicationUser> Register(RegisterData data, string role, ModelStateDictionary modelState);

        Task<bool> SignIn(LoginData data);
        Task SignOut();

        Task<ApplicationUser> GetCurrentUser();
        Task<ApplicationUser> GetUser(ClaimsPrincipal principal);
        Task SetCurrentProfileImageUrl(string url);
    }
}