using System;

public class DisplayNumberFourTimes
{
    public static void Main(string[] args)
    {
        int number;

        Console.Write("Enter a number: ");
        number = int.Parse(Console.ReadLine());

        
        Console.Write("{0} {0} {0} {0}", number);
        Console.WriteLine();

        
        Console.WriteLine("{0}{0}{0}{0}", number);

        
        Console.WriteLine(); 
        Console.Write("Enter another number: ");
        number = int.Parse(Console.ReadLine());

        Console.Write("{0} {0} {0} {0}", number);
        Console.WriteLine();
        Console.WriteLine("{0}{0}{0}{0}", number);
        Console.ReadLine();
    }
}

