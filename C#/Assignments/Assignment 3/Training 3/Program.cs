using System;

public class Calculator
{
    public static void Main(string[] args)
    {
        double num1, num2, result;
        char operatorChoice;
        Console.WriteLine("Enter the first number: ");
        num1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second number: ");
        num2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Select an operator:");
        Console.WriteLine("+ for Addition");
        Console.WriteLine("- for Subtraction");
        Console.WriteLine("* for Multiplication");
        Console.WriteLine("/ for Division");
        Console.Write("Enter your choice: ");
        operatorChoice = Convert.ToChar(Console.ReadLine());
        switch (operatorChoice)
        {
            case '+':
                result = num1 + num2;
                Console.WriteLine("{0} + {1} = {2}", num1, num2, result);
                Console.ReadLine();
                break;
            case '-':
                result = num1 - num2;
                Console.WriteLine("{0} - {1} = {2}", num1, num2, result);
                Console.ReadLine();
                break;
            case '*':
                result = num1 * num2;
                Console.WriteLine("{0} * {1} = {2}", num1, num2, result);
                Console.ReadLine();
                break;
            case '/':
                if (num2 == 0)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                    Console.ReadLine();
                }
                else
                {
                    result = num1 / num2;
                    Console.WriteLine("{0} / {1} = {2}", num1, num2, result);
                    Console.ReadLine();
                }
                break;
            default:
                Console.WriteLine("Invalid operator entered.");
                Console.ReadLine();
                break;
        }
    }
}
