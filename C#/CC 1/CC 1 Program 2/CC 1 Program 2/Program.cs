using System;

public class SwapFirstLastChar
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a string:");
        string inputString = Console.ReadLine();

        if (inputString.Length < 2)
        {
            Console.WriteLine("String must contain at least two characters.");
            return; 
        }

        char firstChar = inputString[0];
        char lastChar = inputString[inputString.Length - 1];

        string swappedString = lastChar + inputString.Substring(1, inputString.Length - 2) + firstChar;

        Console.WriteLine("Swapped string: {0}", swappedString);
        Console.ReadLine();
    }
}
