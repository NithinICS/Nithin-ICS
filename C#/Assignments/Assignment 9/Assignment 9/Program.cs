using System;

public class MarksAnalysis
{
    public static void Main(string[] args)
    {
        int[] marks = new int[10];
        int total = 0;

        Console.WriteLine("Enter ten marks:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write("Mark {0}: ", i + 1);
            marks[i] = Convert.ToInt32(Console.ReadLine());
            total += marks[i];
        }

        double average = (double)total / 10;

        int min = FindMinimum(marks);
        int max = FindMaximum(marks);

        Console.WriteLine("\nTotal marks: {0}", total);
        Console.WriteLine("Average marks: {0:F2}", average);
        Console.WriteLine("Minimum marks: {0}", min);
        Console.WriteLine("Maximum marks: {0}", max);

        Array.Sort(marks);

        Console.WriteLine("\nMarks in ascending order:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write("{0} ", marks[i]);
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = i + 1; j < 10; j++)
            {
                if (marks[i] < marks[j])
                {
                    int temp = marks[i];
                    marks[i] = marks[j];
                    marks[j] = temp;
                }
            }
        }

        Console.WriteLine("\n\nMarks in descending order:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write("{0} ", marks[i]);
            Console.ReadLine();
        }
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
