using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public decimal EmpSalary { get; set; }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {

            employees.Add(new Employee { EmpId = 1, EmpName = "Nithin", EmpCity = "Bangalore", EmpSalary = 45000m });
            employees.Add(new Employee { EmpId = 2, EmpName = "Gurukiran", EmpCity = "Hyderabad", EmpSalary = 34000m });
            employees.Add(new Employee { EmpId = 3, EmpName = "Shivraj", EmpCity = "Vizag", EmpSalary = 27000m });
            employees.Add(new Employee { EmpId = 4, EmpName = "Raghav", EmpCity = "Noida", EmpSalary = 31000m });

            // Display all employees data
            Console.WriteLine("All employees data:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"EmpId: {employee.EmpId}, EmpName: {employee.EmpName}, EmpCity: {employee.EmpCity}, EmpSalary: {employee.EmpSalary}");
            }


            Console.WriteLine("\nEmployees with salary greater than 45000:");
            foreach (var employee in employees.Where(e => e.EmpSalary > 45000m))
            {
                Console.WriteLine($"EmpId: {employee.EmpId}, EmpName: {employee.EmpName}, EmpCity: {employee.EmpCity}, EmpSalary: {employee.EmpSalary}");
            }


            Console.WriteLine("\nEmployees from Bangalore:");
            foreach (var employee in employees.Where(e => e.EmpCity == "Bangalore"))
            {
                Console.WriteLine($"EmpId: {employee.EmpId}, EmpName: {employee.EmpName}, EmpCity: {employee.EmpCity}, EmpSalary: {employee.EmpSalary}");
            }


            Console.WriteLine("\nEmployees by name in Ascending order:");
            foreach (var employee in employees.OrderBy(e => e.EmpName))
            {
                Console.WriteLine($"EmpId: {employee.EmpId}, EmpName: {employee.EmpName}, EmpCity: {employee.EmpCity}, EmpSalary: {employee.EmpSalary}");
                Console.ReadLine();
            }
        }

    }
}