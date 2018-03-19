using System;
using System.Linq;

namespace LAB_SumOfAllElementsOfMatrix
{
    public class MatrixElementsSum
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split(new[] { ", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] matrix = new int[sizes[0]][];
            for (int row = 0; row < sizes[0]; row++)
            {
                matrix[row] = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            Console.WriteLine($"{matrix.Length}");
            Console.WriteLine($"{matrix[0].Length}");
            var sum = 0;
            foreach (var array in matrix)
            {
                sum += array.Sum();
            }
            Console.WriteLine(sum);
        }
    }
}
