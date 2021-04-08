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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Does nothing:
            // base.OnModelCreating(modelBuilder);

            SeedTechnologies(modelBuilder);
        }

        private static void SeedTechnologies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasKey(enrollment => new // anonymous type, similar to JS {}
                {
                    enrollment.CourseId,
                    enrollment.StudentId,
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

        public DbSet<Technology> Technologies { get; set; }
    }
}
