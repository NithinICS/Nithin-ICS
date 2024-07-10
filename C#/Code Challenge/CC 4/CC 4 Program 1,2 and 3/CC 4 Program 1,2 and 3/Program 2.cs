using System;
using System.Collections.Generic;
using System.Linq;

namespace CC4
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }
    class Employee_prg
    {
        public static void Employee_List()
        {
            List<Employee> empList = new List<Employee>
        {
            new Employee { EmployeeID = 1001, FirstName = "Nithin", LastName = "Jaadeesh", Title = "Manager", DOB = new DateTime(2001, 01, 14), DOJ = new DateTime(2011, 6, 8), City = "Banglore" },
            new Employee { EmployeeID = 1002, FirstName = "Raghu", LastName = "Reddy", Title = "AsstManager", DOB = new DateTime(2002, 09, 23), DOJ = new DateTime(2012, 7, 7), City = "Chennai" },
            new Employee { EmployeeID = 1003, FirstName = "Raghav", LastName = "G", Title = "Consultant", DOB = new DateTime(2000, 15, 16), DOJ = new DateTime(2015, 4, 12), City = "Noida" },
            new Employee { EmployeeID = 1004, FirstName = "Jahanavi", LastName = "Ooo", Title = "Software Engineer", DOB = new DateTime(2001, 26, 13), DOJ = new DateTime(2016, 2, 2), City = "Hyderabad" },
            new Employee { EmployeeID = 1005, FirstName = "Tanmayeee", LastName = "J", Title = "Software Engineer", DOB = new DateTime(2000, 23, 28), DOJ = new DateTime(2016, 2, 2), City = "Vizag" },
            new Employee { EmployeeID = 1006, FirstName = "Ayeesha", LastName = "MUskan", Title = "Consultant", DOB = new DateTime(2001, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Banglore" },
            new Employee { EmployeeID = 1007, FirstName = "Abhishek", LastName = "Lomte", Title = "Consultant", DOB = new DateTime(2001, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Chennai" },
            new Employee { EmployeeID = 1008, FirstName = "Shivraj", LastName = "Patil", Title = "Associate", DOB = new DateTime(2002, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Hyderabad" },
            new Employee { EmployeeID = 1009, FirstName = "Hamsa", LastName = "H", Title = "Associate", DOB = new DateTime(2001, 18, 12), DOJ = new DateTime(2014, 12, 3), City = "Noida" },
            new Employee { EmployeeID = 1010, FirstName = "Guru", LastName = "Kiran", Title = "Manager", DOB = new DateTime(2001, 24, 12), DOJ = new DateTime(2016, 1, 2), City = "Banglore" }
        };

            Console.WriteLine("Displaying details of all employees:");
            DisplayEmployees(empList);

            Console.WriteLine(" Displaying details of employees whose location is not Mumbai:");
            var Not_In_Mumbai = empList.Where(emp => emp.City != "Banglore");
            DisplayEmployees(Not_In_Mumbai.ToList());

            Console.WriteLine("Displaying details of employees whose title is AsstManager:");
            var asstManagers = empList.Where(emp => emp.Title == "AsstManager");
            DisplayEmployees(asstManagers.ToList());

            Console.WriteLine(" Displaying details of employees whose Last Name starts with 'S':");
            var employees_LastName_S = empList.Where(emp => emp.LastName.StartsWith("S"));
            DisplayEmployees(employees_LastName_S.ToList());
        }
        static void DisplayEmployees(List<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"EmployeeID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB.ToShortDateString()}, DOJ: {emp.DOJ.ToShortDateString()}, City: {emp.City}");
            }
        }
    }
}