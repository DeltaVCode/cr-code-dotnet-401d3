using System;
using Xunit;

namespace Demo
{
    public class BookTests
    {
        [Fact]
        public void Can_create_a_Book()
        {
            var initialBookCount = Book.BookCount;

            Book book1 = new Book("C# in Depth");
            // book1.Author = null; // error!
            // book1.Author = new Author("Prince", null); // error!

            Book book2 = new Book("C# out of Depth");

            // Assert.Equal("C# in Depth", book1.title); // Field is private
            // book1.title = null; // Field is readonly
            Assert.Equal("C# in Depth", book1.Title); // Property
            // book1.Title = "oops"; // get-only Property
            Assert.Equal("C# out of Depth", book2.Title);

            Assert.Equal("C# in Depth", book1.GetTitle()); // Getter method (Java)

            book1.Publisher = "O'Reilly";
            Assert.Equal("O'Reilly", book1.Publisher);

            book1.Author = new Author("Ben", "Something");
            Assert.Equal("Ben Something", book1.Author.FullName);

            string formattedBook = book1.FormatBookTitleAndAuthor();
            Assert.Equal("C# in Depth by Ben Something", formattedBook);


            Assert.Equal(initialBookCount + 2, Book.BookCount);
        }

        [Fact]
        public void Cannot_assign_null_Author()
        {
            // Arrange
            Book book = new Book("Test");

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                book.Author = null;
            });

            try
            {
                // Act
                book.Author = null;

                throw new InvalidOperationException("Setting Author should have thrown!");
            }
            catch (ArgumentNullException)
            {
                // Assert: we got here!
            }

        }
    }
}
