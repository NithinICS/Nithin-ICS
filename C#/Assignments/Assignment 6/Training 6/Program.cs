using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a number 1:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter a number 2:");
            int b = Convert.ToInt32(Console.ReadLine());
            int sum = 0;

            if (a == b)
            {
                sum = (a + b) * 3;
            }
            else
            {
                sum = a + b;
            }
            Console.WriteLine("The Sum of given inputs:"+sum);
            Console.ReadLine();

        }
    }
}
