using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoWeb.Data;
using DemoWeb.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DemoWeb.Tests.Data
{
    public class DatabaseStudentRepositoryTests : DatabaseTestBase
    {
        [Fact]
        public async Task Can_get_Students()
        {
            // Arrange
            // var doug = await _db.Students.SingleAsync(); // Dougie Fresh
            var s1 = await CreateAndSaveTestStudent();
            var s2 = await CreateAndSaveTestStudent();

            var studentRepo = new DatabaseStudentRepository(_db);

            // Act
            var students = await studentRepo.GetAllStudents();

            // Assert
            Assert.Contains(s1, students);
            Assert.Contains(s2, students);
        }

        [Fact]
        public async Task Can_add_student()
        {
            // Arrange
            var saveMe = new Student { FirstName = "Bob", LastName = "Barker" };

            var studentRepo = new DatabaseStudentRepository(_db);

            // Act
            await studentRepo.CreateStudent(saveMe);

            // Assert
            Assert.NotEqual(0, saveMe.Id);

            var saved = await studentRepo.GetStudent(saveMe.Id);
            Assert.NotNull(saved);
            Assert.Equal(saveMe.FirstName, saved.FirstName);
        }
    }
}
