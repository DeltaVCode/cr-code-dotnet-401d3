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
    }
}
