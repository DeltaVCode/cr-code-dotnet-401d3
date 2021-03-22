

using System;
using ConsoleApp1.Data;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array array = new Array();

            Console.WriteLine("Hello World!");

            // Stuff stuff = new Stuff();

            //object num = 123;
            //Stuff.Test((string)num); // Compiler error - can't convert int to string

            Stuff.Test("123");
            Stuff.Test(123.ToString());

            Stuff.Test(123);
        }
    }
}