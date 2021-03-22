using System;

namespace ConsoleApp1.Data
{
    class Stuff
    {
        public static void Test(string name)
        {
            Console.WriteLine("Testing from Stuff!");
            Console.WriteLine("hello, " + name);
            Console.WriteLine();
            Console.WriteLine(true);
        }
        public static void Test(int number)
        {
            Console.WriteLine("Lucky number is " + number);
        }
    }
}

// Don't to this (but it is possible)
namespace ConsoleApp1.Stupid
{
    class Stuff
    {
        public static void Test2() { }
    }

    class Array
    {

    }
}
