using System;

public class StringCharRemover
{
    public static string RemoveCharAt(string str, int position)
    {
        if (str == null)
        {
            throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
        }

        if (position < 0 || position >= str.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position must be within the range of 0 to string length - 1.");
        }

        return str.Substring(0, position) + str.Substring(position + 1);
    }

    public static void Main(string[] args)
    {
        string inputString;
        int position;

        Console.WriteLine("Enter a string:");
        inputString = Console.ReadLine();

        Console.WriteLine("Enter the position of the character to remove (0 to {0}):", inputString.Length - 1);
        position = int.Parse(Console.ReadLine());

        try
        {
            string modifiedString = RemoveCharAt(inputString, position);
            Console.WriteLine("Modified string: {0}", modifiedString);
            Console.ReadLine();
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Error: {0}", ex.Message);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Error: {0}", ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid input for position. Please enter an integer.");
            Console.ReadLine();
        }
    }
}