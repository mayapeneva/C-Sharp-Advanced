using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var degrees = int.Parse(Console.ReadLine().Trim().Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)[1]);

        var queue = new Queue<string>();
        var rowsNumber = 0;
        var longestCol = 0;
        string input;
        while ((input = Console.ReadLine().Trim()) != "END")
        {
            queue.Enqueue(input);
            rowsNumber++;
            if (longestCol < input.Length)
            {
                longestCol = input.Length;
            }
        }

        while (degrees >= 360)
        {
            degrees -= 360;
        }

        if (degrees == 0)
        {
            var matrix = new char[rowsNumber][];
            RotateMatrix0Degrees(queue, rowsNumber, matrix);

            PrintMatrix(matrix);
        }
        else if (degrees == 90)
        {
            var matrix = new char[longestCol][];
            RotateMatrix90Degrees(queue, rowsNumber, longestCol, matrix);

            PrintMatrix(matrix);
        }
        else if (degrees == 180)
        {
            var matrix = new char[rowsNumber][];
            RotateMatrix180Degrees(queue, rowsNumber, longestCol, matrix);

            PrintMatrix(matrix);
        }
        else if (degrees == 270)
        {
            var matrix = new char[longestCol][];
            RotateMatrix270Degrees(queue, rowsNumber, longestCol, matrix);

            PrintMatrix(matrix);
        }
    }

    private static void RotateMatrix270Degrees(Queue<string> queue, int rowsNumber, int longestCol, char[][] matrix)
    {
        for (int i = 0; i < longestCol; i++)
        {
            matrix[i] = new char[rowsNumber];
        }

        for (int col = 0; col < rowsNumber; col++)
        {
            var currentRow = queue.Dequeue();
            var index = 0;
            for (int row = longestCol - 1; row >= longestCol - currentRow.Length; row--)
            {
                matrix[row][col] = currentRow[index];
                index++;
            }
        }
    }

    private static void RotateMatrix180Degrees(Queue<string> queue, int rowsNumber, int longestCol, char[][] matrix)
    {
        for (int row = rowsNumber - 1; row >= 0; row--)
        {
            var currentRow = queue.Dequeue();
            var index = 0;
            matrix[row] = new char[longestCol];
            for (int col = longestCol - 1; col >= longestCol - currentRow.Length; col--)
            {
                matrix[row][col] = currentRow[index];
                index++;
            }
        }
    }

    private static void RotateMatrix90Degrees(Queue<string> queue, int rowsNumber, int longestCol, char[][] matrix)
    {
        for (int i = 0; i < longestCol; i++)
        {
            matrix[i] = new char[rowsNumber];
        }

        for (int col = rowsNumber - 1; col >= 0; col--)
        {
            var currentRow = queue.Dequeue();
            var index = 0;
            for (int row = 0; row < currentRow.Length; row++)
            {
                matrix[row][col] = currentRow[index];
                index++;
            }
        }
    }

    private static void RotateMatrix0Degrees(Queue<string> queue, int rowsNumber, char[][] matrix)
    {
        for (int row = 0; row < rowsNumber; row++)
        {
            var currentRow = queue.Dequeue();
            matrix[row] = new char[currentRow.Length];
            for (int col = 0; col < currentRow.Length; col++)
            {
                matrix[row][col] = currentRow[col];
            }
        }
    }

    private static void PrintMatrix(char[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            Console.WriteLine(string.Join("", matrix[i]));
        }
    }
}