using System;
using LendingLibrary.Collections;
using Xunit;

namespace LendingLibrary.Tests.Collections
{
    public class BackpackTests
    {
        [Fact]
        public void Backpack_starts_empty()
        {
            // Arrange / Act
            Backpack<string> bag = new Backpack<string>();

            // Assert
            Assert.Empty(bag);
        }

        [Fact]
        public void Backpack_can_Pack_something()
        {
            // Arrange
            Backpack<string> bag = new Backpack<string>();

            string item1 = "Water Bottle";
            string item2 = "Compass";

            // Act
            bag.Pack(item1);

            // Assert
            Assert.Equal(new[] { item1 }, bag);

            // Act
            bag.Pack(item2);

            // Assert
            Assert.Equal(new[] { item1, item2 }, bag);
        }

        [Fact]
        public void Backpack_cannot_Pack_null()
        {
            // Arrange;
            Backpack<string> bag = new Backpack<string>();

            // Act
            bag.Pack(null);

            // Assert
            Assert.Empty(bag);
        }

        [Fact]
        public void Backpack_can_Unpack_something()
        {
            // Arrange
            Backpack<string> bag = new Backpack<string>();
            bag.Pack("Water Bottle");
            bag.Pack("Compass");

            // Act
            string removed = bag.Unpack(0);

            // Assert
            Assert.Equal("Water Bottle", removed);
            Assert.Equal(new[] { "Compass" }, bag);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(2)]
        public void Backpack_cannot_Unpack_out_of_range(int badIndex)
        {
            // Arrange
            Backpack<string> bag = new Backpack<string>();
            bag.Pack("Water Bottle");
            bag.Pack("Compass");

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                // Act
                string removed = bag.Unpack(badIndex);
            });
        }
    }
}
