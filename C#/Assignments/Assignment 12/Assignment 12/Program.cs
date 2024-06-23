using System;

public class ReverseWord
{
    public static void Main(string[] args)
    {
        string word;

        Console.Write("Enter a word: ");
        word = Console.ReadLine();

        string reversedWord = ReverseString(word);

        Console.WriteLine("The reversed word is: {0}", reversedWord);
        Console.ReadLine();
    }

    public static string ReverseString(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
