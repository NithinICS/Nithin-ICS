using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4_Ques_1
{
    class Assignment_4_Ques_2
    {


        public class Program
        {
            public static void Main(string[] args)
            {
                Console.Write("Enter a string: ");
                string str = Console.ReadLine();
                Console.Write("Enter a letter to count: ");
                char letter = Console.ReadLine()[0];

                int count = 0;
                foreach (char c in str.ToUpper())
                {
                    if (c == char.ToUpper(letter))
                    {
                        count++;
                    }
                }

                Console.WriteLine("The letter '{0}' appears {1} times in the string.", letter, count);
                Console.ReadLine();
            }
        }
    }
}