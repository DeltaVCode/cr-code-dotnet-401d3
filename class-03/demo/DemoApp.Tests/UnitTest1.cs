using System;
using System.IO;
using Xunit;

namespace DemoApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            // string filePathToWriteTo = $"test.txt";
            // File.Delete(filePathToWriteTo);

            // Good idea to make test input/output paths unique
            string filePathToWriteTo = $"test-{DateTime.Now.Ticks}.txt";

            string textToWrite = "Hello!";

            // Act
            File.AppendAllText(filePathToWriteTo, textToWrite);

            // Assert
            string written = File.ReadAllText(filePathToWriteTo);
            Assert.Equal(textToWrite, written);
        }

        [Fact]
        public void CanReadNames()
        {
            string[] names = File.ReadAllLines("names.txt");

            Assert.Equal(new[] { "Keith", "Stacey", "Craig" }, names);
        }
    }
}
