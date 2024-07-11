using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assignment_6
{
    class Query2
    {
        static void Main(string[] args)
        {
            string[] words = new string[] { "mum", "amsterdam", "bloom" };

            var result = words.Where(w => w.StartsWith("a") && w.EndsWith("m"));

            foreach (var item in result)
            {
                Console.WriteLine(item);
                Console.ReadLine();
            }
        }
    }
}