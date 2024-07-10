using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Test_3_
{
    class Append_Text
    {
        static void Main()
        {
            string filePath = @"D:\N ICS Training 2024\C#\Code Challenge\CC 4\CC4 Pogram1.txt";
            try
            {
                Console.WriteLine("Enter text to append");
                string textToAppend = Console.ReadLine();
                if (File.Exists(filePath))
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(textToAppend);
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine(textToAppend);
                    }
                }
                Console.WriteLine("Text appended successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Encountered an error: {ex.Message}");
                Console.ReadKey();
            }
            Console.Read();
        }
    }
}