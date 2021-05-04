using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Testing.Really
{
    public class CoolModel : PageModel
    {
        public string Name { get; private set; }

        public void OnGet()
        {
            Name = Request.Query["name"];
        }
    }
}
