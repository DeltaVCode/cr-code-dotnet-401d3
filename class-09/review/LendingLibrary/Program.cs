using System;
using LendingLibrary.Collections;
using LendingLibrary.Models;

namespace LendingLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Backpack<Book> books = new Backpack<Book>();
            books.Pack(new Book { Title = "C# in Depth" });

            foreach (Book book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
