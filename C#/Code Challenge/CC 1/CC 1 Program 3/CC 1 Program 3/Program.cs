using System;

public class MultiplicationTable
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Multiplication table of {0}:", number);

        for (int i = 0; i <= 10; i++)
        {
            int product = number * i;
            Console.WriteLine("{0} * {1} = {2}", number, i, product);
            Console.ReadLine();
        }
    }
}
