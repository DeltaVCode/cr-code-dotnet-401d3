namespace FizzBuzz
{
    public class FizzBuzzer
    {
        /// <summary>
        /// Returns "Fizz" for multiples of 3,
        /// returns "Buzz" for multiples of 5,
        /// returns "FizzBuzz" for multiples of both,
        /// else returns the number as a string.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string Convert(int number)
        {
            if (number % 15 == 0)
                return "FizzBuzz";

            if (number % 5 == 0)
                return "Buzz";

            if (number % 3 == 0)
                return "Fizz";

            return number.ToString();
        }
    }
}
