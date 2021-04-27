using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Identity;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext :
        IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Keep this so Identity still works!
            base.OnModelCreating(builder);

            builder.Entity<Course>()
                .HasData(
                new Course { Id = 42, CourseCode = "Life", Price = 123.45m }
                );
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }
    }
}
