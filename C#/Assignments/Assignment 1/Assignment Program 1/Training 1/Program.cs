using System; 
public class IntegerChecker
{
    public static void Main(string[] args)
    {
        int num1, num2;
        Console.WriteLine("Enter the first number: ");
        num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second number: ");
        num2 = int.Parse(Console.ReadLine());
        if (num1 == num2)
        {
            Console.WriteLine("The numbers {0} and {1} are equal.", num1, num2);
        }
        else
        {
            Console.WriteLine("The numbers {0} and {1} are not equal.", num1, num2);
            Console.ReadLine();
        }
    }
}
