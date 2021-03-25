using System;

namespace Demo
{
    public class Author
    {
        // Constructor!
        public Author(string firstName, string lastName)
        {
            if (firstName == null)
                throw new ArgumentNullException(nameof(firstName));
            if (lastName == null)
                throw new ArgumentNullException(nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
        }

        public Author(string firstName, string middleName, string lastName)
            : this(firstName, lastName)
        {
            MiddleName = middleName;
        }

        public string FirstName { get; } // private readonly set
        public string MiddleName { get; set; }
        public string LastName { get; }

        public string FullName
        {
            get
            {
                if (MiddleName != null)
                    return $"{FirstName} {MiddleName} {LastName}";

                return $"{FirstName} {LastName}";
            }
        }
    }
}
