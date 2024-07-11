using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Query1
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 17, 12, 13 };

            var result = numbers.Where(n => n * n > 20)
                                 .Select(n => $"{n} - {n * n}");

            foreach (var item in result)
            {
                Console.WriteLine(item);
                Console.ReadLine();
            }
        }
    }
}