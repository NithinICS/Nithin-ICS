using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC_3_Program_12
{
    class Box

    {

        public int Length { get; set; }

        public int Breadth { get; set; }

        public Box(int length, int breadth)

        {

            Length = length;

            Breadth = breadth;

        }

        public static Box AddBox(Box box1, Box box2)

        {

            Box result = new Box(box1.Length + box2.Length, box1.Breadth + box2.Breadth);

            return result;

        }

        public void Display()

        {

            Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");

        }

    }

    class Test

    {

        static void Main()

        {

            Box box1 = new Box(12, 35);

            Box box2 = new Box(34, 23);

            Console.WriteLine("Box 1 details:");

            box1.Display();

            Console.WriteLine("Box 2 details:");

            box2.Display();

            Box box3 = Box.AddBox(box1, box2);



            Console.WriteLine("Box 3 details (Add Box 1 and Box 2):");

            box3.Display();

            Console.ReadLine();
        }
    }
}