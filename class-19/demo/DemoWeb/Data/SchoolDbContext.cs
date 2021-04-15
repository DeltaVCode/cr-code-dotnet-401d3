using DemoWeb.Models;
using DemoWeb.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeb.Data
{
    public class SchoolDbContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // We now have to have this because IdentityDbContext does stuff
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enrollment>()
                .HasKey(enrollment => new // anonymous type, similar to JS {}
                {
                    enrollment.CourseId,
                    enrollment.StudentId,
                });

            modelBuilder.Entity<Transcript>()
                .HasKey(transcript => new
                {
                    transcript.StudentId,
                    transcript.CourseId,
                });

            modelBuilder.Entity<Technology>()
                .HasData(
                    new Technology { Id = 1, Name = ".NET" },
                    new Technology { Id = 2, Name = "JavaScript" },
                    new Technology { Id = 3, Name = "Java" }
                );

            // Option 1 to remove the decimal warning
            modelBuilder.Entity<Course>()
                .Property(c => c.Price).HasColumnType("money");

            modelBuilder.Entity<Course>()
                .HasData(
                    new Course { Id = 1001, CourseCode = "cr-dotnetd3", Price = 100m }
                );

            modelBuilder.Entity<Student>()
                .HasData(
                    new Student { Id = 42, FirstName = "Douglas", LastName = "Adams" }
                );

            modelBuilder.Entity<Enrollment>()
                .HasData(
                    new Enrollment { CourseId = 1001, StudentId = 42 }
                );
        }

        // Name of this property = name of the table
        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Transcript> Transcripts { get; set; }

        public DbSet<Technology> Technologies { get; set; }
    }
}
