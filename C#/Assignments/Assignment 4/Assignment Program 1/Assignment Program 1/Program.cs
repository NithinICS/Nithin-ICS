using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4_Ques_1
{
    class Program


    {
        private string firstName;
        private string lastName;

        public Program(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public static void Display(Program program)
        {
            Console.WriteLine(program.firstName.ToUpper());
            Console.WriteLine(program.lastName.ToUpper());
        }

        public static void Main(string[] args)
        {
            Program program = new Program("Raghav", "Garg");
            Display(program);
            Console.ReadLine();
        }
    }

}