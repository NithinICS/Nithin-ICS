using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class Program4_Assignment_5
    {


        public interface IStudent
        {
            int StudentId { get; set; }
            string Name { get; set; }

            void ShowDetails();
        }

        public class Dayscholar : IStudent
        {
            public int StudentId { get; set; }
            public string Name { get; set; }

            public void ShowDetails()
            {
                Console.WriteLine("Dayscholar Student Details:");
                Console.WriteLine($"Student ID: {StudentId}");
                Console.WriteLine($"Student Name: {Name}");
            }
        }

        public class Resident : IStudent
        {
            public int StudentId { get; set; }
            public string Name { get; set; }

            public void ShowDetails()
            {
                Console.WriteLine("Resident Student Details:");
                Console.WriteLine($"Student ID: {StudentId}");
                Console.WriteLine($"Student Name: {Name}");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Dayscholar dayscholar = new Dayscholar
                {
                    StudentId = 098765,
                    Name = "Nithin"
                };

                Resident resident = new Resident
                {
                    StudentId = 123456,
                    Name = "Jagadeesh"
                };

                dayscholar.ShowDetails();
                Console.WriteLine();
                resident.ShowDetails();
                Console.ReadLine();
            }
        }
    }
}