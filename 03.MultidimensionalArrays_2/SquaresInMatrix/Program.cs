using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = sizes[0];
        var c = sizes[1];

        var matrix = new String[r][];
        for (int row = 0; row < r; row++)
        {
            matrix[row] = Console.ReadLine().Trim().Split();
        }

        var count = 0;
        for (int rIndex = 0; rIndex < r - 1; rIndex++)
        {
            for (int cIndex = 0; cIndex < c - 1; cIndex++)
            {
                if (matrix[rIndex][cIndex] == matrix[rIndex][cIndex + 1]
                    && matrix[rIndex][cIndex] == matrix[rIndex + 1][cIndex]
                    && matrix[rIndex][cIndex] == matrix[rIndex + 1][cIndex + 1])
                {
                    count++;
                }
            }
        }

        Console.WriteLine(count);
    }
}