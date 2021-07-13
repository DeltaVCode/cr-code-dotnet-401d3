using System.Collections.Generic;
using System.Threading.Tasks;
using DemoWeb.Controllers;
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
    }
}
