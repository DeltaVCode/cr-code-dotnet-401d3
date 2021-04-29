using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Identity;

namespace WebApplication1.Models.ViewModels
{
    public class AccountIndexViewModel
    {
        public ApplicationUser User { get; set; }

        public List<object> Profiles { get; set; }
    }
}
