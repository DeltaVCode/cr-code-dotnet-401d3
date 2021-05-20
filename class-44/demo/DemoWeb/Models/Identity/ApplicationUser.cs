﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DemoWeb.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? DeltaVGraduationDate { get; set; }
    }
}
