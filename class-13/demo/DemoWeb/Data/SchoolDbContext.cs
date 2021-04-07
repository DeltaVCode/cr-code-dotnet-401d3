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

            modelBuilder.Entity<Technology>()
                .HasData(
                    new Technology { Id = 1, Name = ".NET" },
                    new Technology { Id = 2, Name = "JavaScript" },
                    new Technology { Id = 3, Name = "Java" }
                );
        }

        // Name of this property = name of the table
        public DbSet<Student> Students { get; set; }

        public DbSet<Technology> Technologies { get; set; }
    }
}
