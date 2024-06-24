using System;

public class ArrayCopy
{
    public static void Main(string[] args)
    {
        int[] sourceArray;
        int[] destinationArray;
        int size;

        Console.Write("Enter the size of the array: ");
        size = Convert.ToInt32(Console.ReadLine());

        sourceArray = new int[size];
        destinationArray = new int[size];

        Console.WriteLine("Enter {0} integer values for the source array:", size);
        for (int i = 0; i < size; i++)
        {
            Console.Write("Element {0}: ", i + 1);
            sourceArray[i] = Convert.ToInt32(Console.ReadLine());
        }

        for (int i = 0; i < size; i++)
        {
            destinationArray[i] = sourceArray[i];
        }

        Console.WriteLine("\nSource array:");
        for (int i = 0; i < size; i++)
        {
            Console.Write("{0} ", sourceArray[i]);
        }

        Console.WriteLine("\n\nDestination array:");
        for (int i = 0; i < size; i++)
        {
            Console.Write("{0} ", destinationArray[i]);
        }
        Console.WriteLine();
        Console.ReadLine();
    }
}
