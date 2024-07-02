using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class Program3_Assignment_5
    {


        public class Employee
        {
            public int Empid { get; set; }
            public string Empname { get; set; }
            public float Salary { get; set; }

            public Employee(int empid, string empname, float salary)
            {
                Empid = empid;
                Empname = empname;
                Salary = salary;
            }

            public void Display()
            {
                Console.WriteLine($"Empid: {Empid}, Empname: {Empname}, Salary: {Salary}");
            }
        }

        public class ParttimeEmployee : Employee
        {
            public float Wages { get; set; }

            public ParttimeEmployee(int empid, string empname, float salary, float wages)
                : base(empid, empname, salary)
            {
                Wages = wages;
            }

            public new void Display()
            {
                base.Display();
                Console.WriteLine($"Wages: {Wages}");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                ParttimeEmployee parttimeEmployee = new ParttimeEmployee(1, "Nithin J",12345, 123);

                parttimeEmployee.Display();
                Console.ReadLine();
            }
        }


    }
}