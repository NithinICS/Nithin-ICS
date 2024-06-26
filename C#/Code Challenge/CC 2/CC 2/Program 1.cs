

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC_2
{
    class Program_1
    {
        // Abstract class 
        public abstract class Student
        {
            public string Name { get; set; }
            public int StudentId { get; set; }
            public double Grade { get; set; }

            public abstract bool IsPassed(double grade);
        }

        // Undergraduate
        public class Undergraduate : Student
        {
            public override bool IsPassed(double grade)
            {
                return grade > 70.0;
            }
        }

        // Graduate
        public class Graduate : Student
        {
            public override bool IsPassed(double grade)
            {
                return grade > 80.0;
            }
        }

        static void Main(string[] args)
        {
            Undergraduate ug = new Undergraduate { Name = "Jagadeesh", StudentId = 1234567, Grade = 95 };
            Graduate g = new Graduate { Name = "Nithin", StudentId = 1234568, Grade = 62.55 };

            Console.WriteLine($"{ug.Name} is {(ug.IsPassed(ug.Grade) ? "passed" : "not passed")}");
            Console.WriteLine($"{g.Name} is {(g.IsPassed(g.Grade) ? "passed" : "not passed")}");
            Console.ReadLine();
        }
    }
}