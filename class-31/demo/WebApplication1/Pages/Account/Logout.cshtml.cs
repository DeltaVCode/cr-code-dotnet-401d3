using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Services.Identity;

namespace WebApplication1.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly IUserService userService;

        public LogoutModel(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult OnGet()
        {
            return NotFound();
        }

        public async Task<IActionResult> OnPost()
        {
            await userService.SignOut();
            return Redirect("/");
        }
    }
}
