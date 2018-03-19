using System;
using System.Linq;

namespace EXER_MaximalSum
{
    public class MaximalSum
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var r = sizes[0];

            var matrix = new int[r][];
            for (int i = 0; i < r; i++)
            {
                matrix[i] = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            }

            var maxSum = 0;
            var maxRow = 0;
            var maxCol = 0;
            for (int row = 0; row < matrix.Length - 2; row++)
            {
                var tempSum = 0;
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    tempSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2]
                              + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2]
                              + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (tempSum > maxSum)
                    {
                        maxSum = tempSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine($"{matrix[maxRow + j][maxCol]} {matrix[maxRow + j][maxCol + 1]} {matrix[maxRow + j][maxCol + 2]}");
            }
        }
    }
}