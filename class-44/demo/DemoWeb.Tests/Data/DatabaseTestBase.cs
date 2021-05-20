using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoWeb.Data;
using DemoWeb.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DemoWeb.Tests.Data
{
    public abstract class DatabaseTestBase : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly SchoolDbContext _db;

        public DatabaseTestBase()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new SchoolDbContext(
                new DbContextOptionsBuilder<SchoolDbContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        protected async Task<Student> CreateAndSaveTestStudent()
        {
            var student = new Student { FirstName = "Test", LastName = "Whatever" };
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, student.Id); // Sanity check
            return student;
        }

        protected async Task<Course> CreateAndSaveTestCourse()
        {
            var course = new Course { CourseCode = "test" };
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, course.Id); // Sanity check
            return course;
        }
    }
}
