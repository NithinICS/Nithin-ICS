using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC_3_Program_12
{
    class Cricket
    {
        public List<int> scores = new List<int>();

        public void Pointscalculation(int no_of_matches)
        {
            Console.WriteLine($"Enter scores for {no_of_matches} matches:");
            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Match {i + 1} score: ");
                int score = Convert.ToInt32(Console.ReadLine());
                scores.Add(score);
            }

            int total_score = scores.Sum();
            double average_score = (double)total_score / no_of_matches;
            Console.WriteLine($"\nTotal Sum of Scores: {total_score}");
            Console.WriteLine($"Average Score: {average_score:F2}");
        }
    }

    class Program
    {
        static void Main()
        {
            Cricket ipl = new Cricket();
            int no_of_matches;

            Console.Write("Enter number of matches: ");
            no_of_matches = Convert.ToInt32(Console.ReadLine());

            ipl.Pointscalculation(no_of_matches);
            Console.ReadLine();
        }
    }
}