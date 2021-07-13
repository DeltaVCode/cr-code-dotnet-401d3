using System.Collections.Generic;
using System.Threading.Tasks;
using DemoWeb.Controllers;
using DemoWeb.Models;
using DemoWeb.Models.Api;
using DemoWeb.Services;
using Moq;
using Xunit;

namespace DemoWeb.Tests.Controllers
{
    public class TranscriptsControllerTests
    {
        [Fact]
        public async Task Get_by_studentId_returns_grades()
        {
            // Arrange
            var studentId = 42;

            var transcriptEntries = new List<TranscriptDto>
            {
                new TranscriptDto(),
                new TranscriptDto(),
            };

            var repoMock = new Mock<ITranscriptRepository>();
            repoMock.Setup(r => r.GetAll(studentId)).ReturnsAsync(transcriptEntries);

            var controller = new TranscriptsController(repoMock.Object);

            // Act
            var result = await controller.Get(studentId);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(transcriptEntries, result);
        }

        [Fact]
        public async void Post_saves_student()
        {
            // Arrange
            var studentId = 50;

            var createTranscript = new CreateTranscript
            {
                CourseId = 12,
                Grade = "B",
            };

            var repoMock = new Mock<ITranscriptRepository>();

            var controller = new TranscriptsController(repoMock.Object);

            // Act
            await controller.Post(studentId, createTranscript);

            // Assert
            repoMock.Verify(r => r.AddToTranscript(studentId, createTranscript));
        }
    }
}
