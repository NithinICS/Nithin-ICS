using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4_Ques_1
{
    class Assignment_4_Ques_4
    {
        public class Scholarship
        {
            public decimal Merit(decimal marks, decimal fees)
            {
                if (marks >= 70 && marks <= 80)
                {
                    return fees * 0.2m;
                }
                else if (marks > 80 && marks <= 90)
                {
                    return fees * 0.3m;
                }
                else if (marks > 90)
                {
                    return fees * 0.5m;
                }
                else
                {
                    return 0;
                }
            }
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                Scholarship scholarship = new Scholarship();
                decimal marks = 85;
                decimal fees = 10000;
                decimal amount = scholarship.Merit(marks, fees);
                Console.WriteLine("Scholarship amount: " + amount);
                Console.ReadLine();
            }
        }
    }
}