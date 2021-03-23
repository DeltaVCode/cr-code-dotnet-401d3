using Xunit;

namespace FizzBuzz.Tests
{
    public class FizzBuzzerTests
    {
        [Fact]
        public void Convert_returns_number_when_not_divisible_by_three_or_five()
        {
            // Arrange
            int number = 1;

            // Act
            string result = FizzBuzzer.Convert(number);

            // Assert
            Assert.Equal("1", result);
        }
        [Fact]
        public void Convert_returns_a_different_number_when_not_divisible_by_three_or_five()
        {
            // Arrange
            int number = 2;

            // Act
            string result = FizzBuzzer.Convert(number);

            // Assert
            Assert.Equal("2", result);
        }
    }
}
