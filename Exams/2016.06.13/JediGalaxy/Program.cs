using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var sizes = Console.ReadLine().Split().Select(int.Parse)
            .ToArray();
        var rows = sizes[0];
        var cols = sizes[1];

        var matrix = new int[rows, cols];
        FillMatrixIn(rows, cols, matrix);

        long stars = 0;
        string input;
        while ((input = Console.ReadLine()) != "Let the Force be with you")
        {
            var ivosCoordinates = input.Split().Select(int.Parse).ToArray();
            var evilsCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var eRow = evilsCoordinates[0];
            var eCol = evilsCoordinates[1];

            while (true)
            {
                if (IsValid(matrix, eRow, eCol))
                {
                    matrix[eRow, eCol] = 0;
                }
                eRow--;
                eCol--;

                if (eRow == -1 || eCol == -1)
                {
                    break;
                }
            }

            var iRow = ivosCoordinates[0];
            var iCol = ivosCoordinates[1];
            while (true)
            {
                if (IsValid(matrix, iRow, iCol))
                {
                    stars += matrix[iRow, iCol];
                }
                iRow--;
                iCol++;

                if (iRow == -1 || iCol == cols)
                {
                    break;
                }
            }
        }

        Console.WriteLine(stars);
    }

    private static bool IsValid(int[,] matrix, int row, int col)
    {
        return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }

    private static void FillMatrixIn(int rows, int cols, int[,] matrix)
    {
        var number = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                matrix[r, c] = number;
                number++;
            }
        }
    }
}