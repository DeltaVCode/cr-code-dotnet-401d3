using System;

namespace ConsoleApp1.Data
{
    class Stuff
    {
        public static void Test(string name)
        {
            Console.WriteLine("Testing from Stuff!");
            Console.WriteLine("hello, " + name);
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
