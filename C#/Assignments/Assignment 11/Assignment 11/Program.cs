using System;

public class WordLength
{
    public static void Main(string[] args)
    {
        string word;

        Console.Write("Enter a word: ");
        word = Console.ReadLine();

        int length = word.Length;

        Console.WriteLine("The length of the word is: {0}", length);
        Console.ReadLine();
    }
}
