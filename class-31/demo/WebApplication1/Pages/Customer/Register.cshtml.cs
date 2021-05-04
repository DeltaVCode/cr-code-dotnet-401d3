using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models.Identity;
using WebApplication1.Services.Identity;

namespace WebApplication1.Pages.Customer
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService userService;

        public RegisterModel(IUserService userService)
        {
            this.userService = userService;
        }

        [BindProperty]
        public RegisterData Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // similar to return View() in Controller
            }

            await userService.Register(Input, ApplicationRole.Customer, ModelState);

            // Might have duplicate email, invalid password, etc
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Redirect("~/");
        }
    }
}
