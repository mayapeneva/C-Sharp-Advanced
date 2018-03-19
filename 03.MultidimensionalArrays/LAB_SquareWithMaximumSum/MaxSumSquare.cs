using System;
using System.Linq;

namespace LAB_SquareWithMaximumSum
{
    public class MaxSumSquare
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] matrix = new int[sizes[0]][];
            for (int row = 0; row < sizes[0]; row++)
            {
                matrix[row] = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var maxSum = 0;
            var maxSumRow = 0;
            var maxSumCol = 0;
            for (int rowIndex = 0; rowIndex < matrix.Length-1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length-1; colIndex++)
                {
                    var tempSum = matrix[rowIndex][colIndex] + matrix[rowIndex][colIndex + 1] +
                                  matrix[rowIndex + 1][colIndex] + matrix[rowIndex + 1][colIndex + 1];
                    if (tempSum > maxSum)
                    {
                        maxSum = tempSum;
                        maxSumRow = rowIndex;
                        maxSumCol = colIndex;
                    }
                }

            }

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"{matrix[maxSumRow + i][maxSumCol]} {matrix[maxSumRow + i][maxSumCol + 1]}");
            }
            Console.WriteLine(maxSum);
        }
    }
}
