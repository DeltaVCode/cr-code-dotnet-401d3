using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoWeb.Controllers;
using DemoWeb.Data;
using DemoWeb.Models.Api;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DemoWeb.Tests.Controllers
{
    public class StudentsControllerTests
    {
        [Fact]
        public async Task GetStudent_returns_NotFound_for_invalid_id()
        {
            // Arrange
            // Mock Context/Repository so we can specify their behavior
            var mockRepo = new Mock<IStudentRepository>();
            var studentRepository = mockRepo.Object;

            var controller = new StudentsController(null, studentRepository);

            // Act
            var result = await controller.GetStudent(7);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
        
        [Fact]
        public async Task GetStudent_returns_StudentDto_from_repository_given_good_id()
        {
            // Arrange
            var studentDto = new StudentDto { StudentId = 42 };

            // Mock Context/Repository so we can specify their behavior
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(r => r.GetStudent(42)).ReturnsAsync(studentDto);
            var studentRepository = mockRepo.Object;

            var controller = new StudentsController(null, studentRepository);

            // Act
            var result = await controller.GetStudent(50);

            // Assert
            Assert.Null(result.Result);
            Assert.Equal(studentDto, result.Value);
        }
    }
}
