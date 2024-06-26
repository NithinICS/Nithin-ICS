using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_2CC2
{
    class Assesment_2_Q3
    {
        // Process input number 
        static void ProcessNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number cannot be negative.");
            }
            else
            {
                Console.WriteLine($"Number {number} is valid.");
                Console.ReadLine();
            }
        }

        static void Main()
        {
            try
            {
                // user for input
                Console.Write("Enter a number: ");
                int input = int.Parse(Console.ReadLine());

                // Call method to input
                ProcessNumber(input);
            }
            catch (ArgumentException e)
            {
                // Handle ArgumentException 
                Console.WriteLine($"Error: {e.Message}");
                Console.ReadLine();

            }
            catch (FormatException)
            {
                // Handle FormatException 
                Console.WriteLine("Error: Input must be a valid integer.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                // other exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}