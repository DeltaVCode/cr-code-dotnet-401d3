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

            Stuff.Test(123); // decimal int literal
            Stuff.Test(0x123); // hexadecimal int literal

            var number = -234.5m; // inferred as decimal
            // error! number = "pi";
            Stuff.Test((int)number); // explicit cast

            Stuff.Test((int)"Keith"[0]);
            Console.WriteLine((char)42);

            Console.WriteLine("Sum is " + Stuff.SumOfTwoNumbers());

            while (true)
            {
                int numberFromUser = Stuff.AskForNumber();
                Console.WriteLine("You entered: {0}", numberFromUser);
            }
        }
    }
}