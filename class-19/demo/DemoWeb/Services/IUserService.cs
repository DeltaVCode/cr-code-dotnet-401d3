using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DemoWeb.Models.Api;
using DemoWeb.Models.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DemoWeb.Services
{
    public interface IUserService
    {
        Task<UserDto> Register(RegisterData data, ModelStateDictionary modelState);
        Task<UserDto> Authenticate(string username, string password);
        Task<UserDto> GetUser(ClaimsPrincipal user);
    }
}
