using System;

public class NumberChecker // Optional class definition
{
    public static void Main(string[] args)
    {
        int number;
        Console.WriteLine("Enter a number: ");
        Console.ReadLine();
        try
        {
            number = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.ReadLine();
            return;
        }

        if (number > 0)
        {
            Console.WriteLine("The number {0} is positive.", number);
            Console.ReadLine();
        }
        else if (number < 0)
        {
            Console.WriteLine("The number {0} is negative.", number);
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("The number {0} is zero.", number);
            Console.ReadLine();
            return;
        }
    }
}
