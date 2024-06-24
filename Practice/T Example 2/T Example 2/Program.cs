using System;

namespace DistanceAdder
{
    class Distance
    {
        public int DistanceValue { get; set; } 

        public Distance(int distance)
        {
            DistanceValue = distance;
        }

        public static Distance Add(Distance dis1, Distance dis2)
        {
            Distance totalDistance = new Distance(dis1.DistanceValue + dis2.DistanceValue);
            return totalDistance;
        }

        public void Increment()
        {
            DistanceValue++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int distance1, distance2;

            // Get distance 1 from the user
            Console.WriteLine("Enter distance 1: ");
            string input = Console.ReadLine();

            // Validate and convert distance 1 input
            if (int.TryParse(input, out distance1))
            {
                // Get distance 2 from the user
                Console.WriteLine("Enter distance 2: ");
                input = Console.ReadLine();

                // Validate and convert distance 2 input
                if (int.TryParse(input, out distance2))
                {
                    // Create Distance objects
                    Distance d1 = new Distance(distance1);
                    Distance d2 = new Distance(distance2);

                    // Add the distances
                    Distance totalDistance = Distance.Add(d1, d2);

                    // Increment Distance 1
                    d1.Increment();

                    // Display the incremented distance 1 and total distance
                    Console.WriteLine("Distance 1 incremented: {0}", d1.DistanceValue);
                    Console.WriteLine("Total distance: {0}", totalDistance.DistanceValue);
                }
                else
                {
                    Console.WriteLine("Invalid input for distance 2. Please enter a number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for distance 1. Please enter a number.");
            }

            Console.ReadLine(); // Pause the console before exiting
        }
    }
}
