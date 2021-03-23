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

        [Fact]
        public void Convert_returns_Fizz_for_multiple_of_three()
        {
            // Arrange
            int number = 6;

            // Act
            string result = FizzBuzzer.Convert(number);

            // Assert
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void Convert_returns_Buzz_for_multiple_of_five()
        {
            // Arrange
            int number = 10;

            // Act
            string result = FizzBuzzer.Convert(number);

            // Assert
            Assert.Equal("Buzz", result);
        }

        [Theory]
        [InlineData(0, "FizzBuzz")]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(6, "Fizz")]
        [InlineData(7, "7")]
        [InlineData(10, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(25, "Buzz")]
        [InlineData(30, "FizzBuzz")]
        [InlineData(36, "Fizz")]
        public void Convert_returns_expected_value(int number, string expected)
        {
            // Arrange
            // from Theory parameter

            // Act
            string result = FizzBuzzer.Convert(number);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
