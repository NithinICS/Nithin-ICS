using System;

public class WordComparison
{
    public static void Main(string[] args)
    {
        string word1, word2;

        Console.Write("Enter the first word: ");
        word1 = Console.ReadLine();

        Console.Write("Enter the second word: ");
        word2 = Console.ReadLine();

        bool areSame = word1.Equals(word2);

        if (areSame)
        {
            Console.WriteLine("The words are the same.");
        }
        else
        {
            Console.WriteLine("The words are not the same.");
            Console.ReadLine();
        }
    }
}
