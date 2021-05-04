using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Services;

namespace TodoApi.Components
{
    public class Username : ViewComponent
    {
        readonly IUserService userService;

        public Username(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int number)
        {
            var user = await userService.GetUser(this.UserClaimsPrincipal);
            return View(user);
        }
    }
}
