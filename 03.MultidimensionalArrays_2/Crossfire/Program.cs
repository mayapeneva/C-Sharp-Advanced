using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // позволено e да удариш извън матрицата и импакт радиуса да засегне матрицата
        var sizes = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var r = sizes[0];
        var c = sizes[1];

        var matrix = new List<List<int>>();
        FillTheMatrixIn(r, c, matrix);

        string input;
        while ((input = Console.ReadLine()) != "Nuke it from orbit")
        {
            var arg = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var hitRow = arg[0];
            var hitCol = arg[1];
            var radius = arg[2];
            if (hitCol >= 0 && hitCol < matrix[hitRow].Count)
            {
                VerticalHitting(r, matrix, hitRow, hitCol, radius);
            }
            if (hitRow >= 0 && hitRow < matrix.Count)
            {
                HorizontalHitting(matrix, hitRow, hitCol, radius);
            }
        }

        for (int rowIndex = 0; rowIndex < r; rowIndex++)
        {
            Console.WriteLine(string.Join(" ", matrix[rowIndex]));
        }
    }

    private static void HorizontalHitting(List<List<int>> matrix, int hitRow, int hitCol, int radius)
    {
        var length = radius * 2 + 1;
        var start = hitCol - radius;
        if (start < 0)
        {
            start = 0;
            length += start;
        }
        if (start + length >= matrix[hitRow].Count)
        {
            length -= start + length - matrix[hitRow].Count;
        }

        matrix[hitRow].RemoveRange(start, length);
    }

    private static void VerticalHitting(int r, List<List<int>> matrix, int hitRow, int hitCol, int radius)
    {
        for (int k = radius; k > 0; k--)
        {
            if (hitRow - k >= 0)
            {
                matrix[hitRow - k].RemoveAt(hitCol);
            }

            if (hitRow + k < matrix.Count)
            {
                matrix[hitRow + k].RemoveAt(hitCol);
            }
        }
    }

    private static void FillTheMatrixIn(int r, int c, List<List<int>> matrix)
    {
        var number = 1;
        for (int i = 0; i < r; i++)
        {
            matrix.Add(new List<int>());
            for (int j = 0; j < c; j++)
            {
                matrix[i].Add(j + number);
            }

            number += c;
        }
    }
}