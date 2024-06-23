using System;

public class ArrayStats
{
    public static void Main(string[] args)
    {
        int[] numbers;
        int size;
        
        Console.Write("Enter the size of the array: ");
        size = Convert.ToInt32(Console.ReadLine());

        numbers = new int[size];

        Console.WriteLine("Enter {0} integer values:", size);
        for (int i = 0; i < size; i++)
        {
            Console.Write("Element {0}: ", i + 1);
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        double average = CalculateAverage(numbers);

        int minimum = FindMinimum(numbers);
        int maximum = FindMaximum(numbers);

        Console.WriteLine("\nAverage value: {0}", average);
        Console.WriteLine("Minimum value: {0}", minimum);
        Console.WriteLine("Maximum value: {0}", maximum);
        Console.ReadLine();
    }

    public static double CalculateAverage(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return (double)sum / arr.Length;
    }

    public static int FindMinimum(int[] arr)
    {
        int min = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }
        return min;
    }

    public static int FindMaximum(int[] arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }
}
