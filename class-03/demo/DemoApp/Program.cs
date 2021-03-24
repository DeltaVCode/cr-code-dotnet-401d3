using System;
using System.IO;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string allText = File.ReadAllText("test.txt");
                Console.WriteLine("All Text:");
                Console.WriteLine(allText);

                byte[] allBytes = File.ReadAllBytes("test.txt");
                Console.WriteLine("All Bytes:");
                Console.WriteLine(allBytes);

                string[] allLines = File.ReadAllLines("test.txt");
                Console.WriteLine("All Lines:");
                for (int i = 0; i < allLines.Length; i++)
                    Console.WriteLine($"{i}: {allLines[i]}");
            }
            catch (FileNotFoundException fnfex)
            {
                Console.WriteLine($"File not found: {fnfex.Message}");
            }
            catch (IOException)
            {
                Console.WriteLine("Misc IO error!");
            }
        }
    }
}
