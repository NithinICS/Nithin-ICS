using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class Program2_Assignment__5
    {

        public class Box
        {
            public int Length { get; set; }
            public int Breadth { get; set; }

            public Box(int length, int breadth)
            {
                Length = length;
                Breadth = breadth;
            }

            public static Box AddBoxes(Box box1, Box box2)
            {
                return new Box(box1.Length + box2.Length, box1.Breadth + box2.Breadth);
            }

            public void Display()
            {
                Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
            }
        }

        public class Test
        {
            static void Main(string[] args)
            {
                Box box1 = new Box(5, 3);
                Box box2 = new Box(4, 2);

                Box result = Box.AddBoxes(box1, box2);

                Console.WriteLine("Box 1:");
                box1.Display();

                Console.WriteLine("Box 2:");
                box2.Display();

                Console.WriteLine("Result:");
                result.Display();
                Console.ReadLine();
            }
        }
    }
}