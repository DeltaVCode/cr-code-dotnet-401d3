using System;
using System.Collections.Generic;

namespace Demo
{
    public class Book
    {
        // Static Fields
        private static int bookCount = 0;
        private static List<Book> books = new List<Book>();

        // Static Properties
        public static int BookCount => bookCount; // "expression body" for simple property
        //public static int BookCount { get { return bookCount; } }

        // Fields
        private readonly string title;
        private Author author;

        // Constructor
        public Book(string title, Author author)
        {
            this.title = title;
            this.author = author;
        }

        public Book(string title)
        {
            if (title == null) throw new ArgumentNullException();

            this.title = title;

            bookCount++;
            books.Add(this);
        }

        // Java has to do this because it doesn't have properties
        public string GetTitle()
        {
            return title;
        }

        // Properties
        public string Title
        {
            get { return title; }
        }

        // Automatic property has secret field
        public string Publisher { get; set; }

        public Author Author
        {
            get { return author; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                this.author = value;
            }
        }

        public string Two
        {
            get { return "two"; }
        }

        // Methods
        public string FormatBookTitleAndAuthor()
        {
            if (Author == null)
            {
                return title;
            }

            return $"{Title} by {Author.FullName}";
        }
    }
}
