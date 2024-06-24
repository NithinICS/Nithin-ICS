using System;

public class SwapNumbers
{
    public static void Main(string[] args)
    {
        int number1, number2, temp;

        Console.Write("Enter the first number: ");
        number1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        number2 = int.Parse(Console.ReadLine());

        temp = number1;
        number1 = number2;
        number2 = temp;

        Console.WriteLine("After swapping:");
        Console.WriteLine($"First number: {number1}");
        Console.WriteLine($"Second number: {number2}");
        Console.ReadLine();
    }
}
