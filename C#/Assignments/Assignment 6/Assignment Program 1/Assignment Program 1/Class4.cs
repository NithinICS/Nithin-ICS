using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Assignment_6_Ques_4
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();

                Console.Write("Enter your age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                ConcessionCalculator calculator = new ConcessionCalculator();
                string result = calculator.CalculateConcession(age);

                Console.WriteLine($"Hello, {name}! {result}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        public class ConcessionCalculator
        {
            public string CalculateConcession(int age)
            {
                if (age < 5)
                    return "You are not eligible for concession.";
                else if (age < 18)
                    return "You are eligible for child concession.";
                else if (age < 60)
                    return "You are not eligible for concession.";
                else
                    return "You are eligible for senior citizen concession.";
            }
        }
    }

}