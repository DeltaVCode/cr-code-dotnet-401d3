using DemoWeb.Controllers;
using DemoWeb.Models.Api;
using DemoWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DemoWeb.Tests.Controllers
{
    public class UsersControllerTests
    {
        [Fact]
        public async void Register_returns_validation_problems()
        {
            // Arrange
            var data = new RegisterData();

            var userService = new Mock<IUserService>();
            var controller = new UsersController(userService.Object);

            userService.Setup(s => s.Register(data, controller.ModelState))
                .Callback(() =>
                {
                    controller.ModelState.AddModelError("Email", "Already exists!");
                });

            // Act
            var result = await controller.Register(data);

            // Assert
            var value = result.ShouldHaveValue<ValidationProblemDetails>(400);
            Assert.Contains("Email", value.Errors);
        }
    }
}
