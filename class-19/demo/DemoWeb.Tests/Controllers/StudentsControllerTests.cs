using System.Collections.Generic;
using DemoWeb.Controllers;
using DemoWeb.Data;
using DemoWeb.Models;
using Moq;
using Xunit;

namespace DemoWeb.Tests.Controllers
{
    public class StudentsControllerTests
    {
        [Fact]
        public async void GetStudents_returns_Ok_students()
        {
            // Arrange
            var students = new List<Student> { new Student() };

            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(r => r.GetAllStudents()).ReturnsAsync(students);

            var controller = new StudentsController(mockRepo.Object);

            // Act
            var result = await controller.GetStudents();

            // Assert
            result.ShouldHaveValue(students);
        }
    }
}
