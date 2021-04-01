using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.Tests
{
    public class LinqTests
    {
        private IEnumerable<Author> authors = new[]
        {
            new Author("Keith", "Dahlby", 'M'),
            new Author("Craig", "Barkley", 'M'),
            new Author("Stacey", "Teltser", 'F'),
        };

        [Fact]
        public void Map_is_called_Select_in_LINQ()
        {
            // SELECT FirstName + ' ' + LastName FROM Authors
            IEnumerable<string> names =
                from a in authors
                select $"{a.FirstName} {a.LastName}";

            Assert.Equal(new[] { "Keith Dahlby", "Craig Barkley", "Stacey Teltser" }, names);

            List<string> names2 =
                authors
                    .Select(a => a.FirstName)
                    .ToList(); // Query was "lazy" until we ask to enumerate into a List

            Assert.Equal(new[] { "Keith", "Craig", "Stacey" }, names2);
        }


        [Fact]
        public void Filter_is_called_Where_in_LINQ()
        {
            // SELECT FirstName FROM Authors WHERE FirstName LIKE 'K%'
            IEnumerable<string> names =
                from a in authors
                where a.FirstName.StartsWith("K")
                select a.FirstName;

            Assert.Equal(new[] { "Keith" }, names);

            var firstNameOfFirstNonKAfterSkippingOne =
                authors
                    .Where(a => !a.FirstName.StartsWith("K"))
                    .Skip(1)
                    .Select(a => a.FirstName)
                    .FirstOrDefault();
            Assert.Equal("Stacey", firstNameOfFirstNonKAfterSkippingOne);
        }


        [Fact]
        public void Can_OrderBy()
        {
            // SELECT FirstName + ' ' + LastName FROM Authors
            IEnumerable<string> names =
                from a in authors
                orderby a.LastName descending
                where a.LastName.Contains("e")
                select $"{a.FirstName} {a.LastName}";

            Assert.Equal(new[] { "Stacey Teltser", "Craig Barkley" }, names);
        }


        [Fact]
        public void Can_GroupBy()
        {
            var genders =
                from a in authors
                group a by a.Gender into g
                select new
                {
                    Gender = g.Key,
                    LengthTotal = g.Sum(a => a.FirstName.Length + a.LastName.Length)
                };

            Assert.Contains(genders, gender => gender.Gender == 'F');
            Assert.Contains(genders, gender => gender.LengthTotal == 13);
        }

        [Fact]
        public void Skip_and_Take_with_enough()
        {
            // Arrange
            LinkedList<int> numbers = new LinkedList<int>(Enumerable.Range(1, 7));
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7 }, numbers);

            // Act
            IEnumerable<int> result = numbers.Skip(2).Take(3);

            // Assert
            Assert.Equal(new[] { 3, 4, 5 }, result);

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void Skip_and_Take_with_not_enough()
        {
            // Arrange
            IEnumerable<int> numbers = Enumerable.Range(1, 4);

            // Act
            IEnumerable<int> result = numbers.Skip(2).Take(3);

            // Assert
            Assert.Equal(new[] { 3, 4 }, result);

            Assert.Equal(2, result.Count());

            Assert.Equal(2.5, numbers.Average());
            Assert.Equal(9, numbers.Skip(1).Sum());
            Assert.True(numbers.All(n => n > 0));

            bool anyResult = numbers.Any(n => n % 3 == 0);
            Assert.True(anyResult);

            Assert.Contains(numbers, n => n % 3 == 0);
        }

    }

    class Author
    {
        public Author(string firstName, string lastName, char gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public char Gender { get; }
    }
}
