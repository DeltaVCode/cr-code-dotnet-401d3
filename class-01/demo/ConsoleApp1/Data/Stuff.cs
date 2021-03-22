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

        public static int SumOfTwoNumbers()
        {
            int num1 = AskForNumber();
            int num2 = AskForNumber();
            return num1 + num2;
        }

        public static int AskForNumber()
        {
        prompt:
            Console.Write("Enter a number! ");
            try
            {

                string valueFromUser = Console.ReadLine();

                if (string.IsNullOrEmpty(valueFromUser))
                {
                    Console.WriteLine("Too chicken to pick a number?");
                    return 0;
                }

                return Convert.ToInt32(valueFromUser);
            }
            catch (OverflowException oex)
            {
                Console.WriteLine("Too small or big, silly goose!");
                return -1;
            }
            catch (FormatException fex)
            {
                Console.WriteLine("Invalid number!");
                Console.WriteLine(fex);
                goto prompt;
            }
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
