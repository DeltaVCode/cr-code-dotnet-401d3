using System;

namespace LendingLibrary.Models
{
    public class Author
    {
        public Author(string firstName, string lastName)
        {
            this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}