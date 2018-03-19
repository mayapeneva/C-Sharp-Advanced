using System;
using System.Linq;

namespace EXER_DiagonalDifference
{
    public class DiagonalDiff
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            }

            var sumOne = 0;
            var sumTwo = 0;
            var index = n - 1;
            for (int row = 0; row < n; row++)
            {
                sumOne += matrix[row][row];
                sumTwo += matrix[row][index];
                index--;
            }

            Console.WriteLine(Math.Abs(sumTwo - sumOne));
        }
    }
}
