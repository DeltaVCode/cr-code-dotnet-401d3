using DemoWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeb.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options)
            : base(options)
        {
        }

        // Name of this property = name of the table
        public DbSet<Student> Students { get; set; }
    }
}
