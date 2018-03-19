using System;
using System.Linq;

namespace EXER_FindEvensOdds
{
    public class EvensOrOdds
    {
        public static void Main()
        {
            Predicate<int> evenNumber = n => n % 2 == 0;

            var bounds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var command = Console.ReadLine();

            var lowerBound = bounds[0];
            var upperBound = bounds[1];
            for (int num = lowerBound; num <= upperBound; num++)
            {
                if (command == "even" && evenNumber(num)
                    || command == "odd" && !evenNumber(num))
                {
                    Console.Write($"{num} ");
                }
            }
            Console.WriteLine();
        }
    }
}
