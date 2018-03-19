using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = sizes[0];
        var c = sizes[1];

        var matrix = new string[r, c];
        for (int row = 0; row < r; row++)
        {
            for (int col = 0; col < c; col++)
            {
                matrix[row, col] = $"{(char)(97 + row)}{(char)(97 + col + row)}{(char)(97 + row)}";
            }
        }

        for (int rowIndex = 0; rowIndex < r; rowIndex++)
        {
            for (int colIndex = 0; colIndex < c; colIndex++)
            {
                Console.Write(matrix[rowIndex, colIndex] + ' ');
            }
            Console.WriteLine();
        }
    }
}