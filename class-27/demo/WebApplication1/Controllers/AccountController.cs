using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Identity;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterData data)
        {
            return RedirectToAction(nameof(Welcome));
        }


        [HttpGet("Welcome")]
        public IActionResult Welcome()
        {
            return View();
        }
    }
}
