using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Identity;
using WebApplication1.Services.Identity;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterData data)
        {
            // Check for simple errors, e.g. [Required]
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            await userService.Register(data, ModelState);

            // Now check for errors from Register()
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            return RedirectToAction(nameof(Welcome));
        }


        [HttpGet("Welcome")]
        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            var model = new LoginData
            {
                ReturnUrl = returnUrl,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginData data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            if (!await userService.SignIn(data))
            {
                ModelState.AddModelError(nameof(LoginData.Password), "Email or Password was incorrect.");

                return View(data);
            }

            if (!string.IsNullOrEmpty(data.ReturnUrl))
            {
                return Redirect(data.ReturnUrl);
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
