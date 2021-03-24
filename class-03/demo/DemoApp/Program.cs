using System;
using System.IO;
using System.Text;

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

                // Copy with default encoding - UTF8
                File.WriteAllLines("copy.txt", allLines);

                // Write file out with different encoding
                File.WriteAllLines("unicode.txt", allLines, Encoding.Unicode);

                File.AppendAllLines("append-to-me.txt", allLines);
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
