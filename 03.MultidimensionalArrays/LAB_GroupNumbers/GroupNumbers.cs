using System;
using System.Linq;

namespace LAB_GroupNumbers
{
    public class GroupNumbers
    {
        public static void Main()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var input = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var sizes = new int[3];
            foreach (var token in input)
            {
                sizes[Math.Abs(token % 3)]++;
            }

            int[][] matrix =
            {
                new int[sizes[0]],
                new int[sizes[1]],
                new int[sizes[2]],
            };

            var indexesArray = new []{0, 0, 0};
            foreach (var number in input)
            {
                var reminder = Math.Abs(number % 3);
                matrix[reminder][indexesArray[reminder]] = number;
                indexesArray[reminder]++;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }

            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
        }
    }
}
