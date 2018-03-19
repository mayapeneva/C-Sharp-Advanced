using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = sizes[0];
        var c = sizes[1];

        var matrix = new int[r][];
        for (int rowIndex = 0; rowIndex < r; rowIndex++)
        {
            matrix[rowIndex] = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        }

        var maxSum = 0;
        var starRow = 0;
        var startCol = 0;
        for (int row = 0; row < r - 2; row++)
        {
            for (int col = 0; col < c - 2; col++)
            {
                var currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    starRow = row;
                    startCol = col;
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matrix[starRow + i][startCol + j] + " ");
            }
            Console.WriteLine();
        }
    }
}