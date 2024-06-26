using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    public class Student
    {
        private int rollNo;
        private string name;
        private string className;
        private string semester;
        private string branch;
        private int[] marks = new int[5];
        public Student(int rollNo, string name, string className, string semester, string branch)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.className = className;
            this.semester = semester;
            this.branch = branch;
        }
        public void GetMarks(int mark1, int mark2, int mark3, int mark4, int mark5)
        {
            marks[0] = mark1;
            marks[1] = mark2;
            marks[2] = mark3;
            marks[3] = mark4;
            marks[4] = mark5;
        }
        public void DisplayResult()
        {
            bool fail = false;
            double average = CalculateAverage();
            foreach (int mark in marks)
            {
                if (mark < 35)
                {
                    fail = true;
                    break;
                }
            }
            if (fail)
            {
                Console.WriteLine("Result: Failed (Marks of at least one subject is less than 35)");
            }
            else if (average >= 50)
            {
                Console.WriteLine("Result: Passed");
            }
            else
            {
                Console.WriteLine("Result: Failed (Average marks are less than 50)");
            }
        }
        private double CalculateAverage()
        {
            double sum = 0;
            foreach (int mark in marks)
            {
                sum += mark;
            }
            return sum / marks.Length;
        }
        public void DisplayData()
        {
            Console.WriteLine($"Roll No: {rollNo}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Class: {className}");
            Console.WriteLine($"Semester: {semester}");
            Console.WriteLine($"Branch: {branch}");
            Console.WriteLine("Marks:");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine($"Subject {i + 1}: {marks[i]}");
            }
        }

        public static void Main(string[] args)
        {
            Student student1 = new Student(552, "Nithin", "BE", "First", "Computer's");
            student1.GetMarks(87, 72, 62, 82, 65);
            student1.DisplayData();
            student1.CalculateAverage();
            Console.WriteLine();
            student1.DisplayResult();
            Console.Read();
        }
    }
}