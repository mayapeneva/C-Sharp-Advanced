using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int size;
    private static char[][] matrix;
    private static List<Knight> knights;

    public static void Main()
    {
        size = int.Parse(Console.ReadLine());

        matrix = new char[size][];
        for (int i = 0; i < size; i++)
        {
            matrix[i] = Console.ReadLine().ToCharArray();
        }

        if (size < 3)
        {
            Console.WriteLine(0);
            return;
        }

        FindAllKnights();
        CheckAllKnights();

        var removedKnights = 0;

        while (knights.Any(k => k.NumberOfKnightsToKill > 0))
        {
            var knightToBeRemoved = knights.OrderByDescending(k => k.NumberOfKnightsToKill).First();

            var r = knightToBeRemoved.Row;
            var c = knightToBeRemoved.Col;
            matrix[r][c] = '0';
            removedKnights++;

            knights.Remove(knightToBeRemoved);

            CheckAllKnights();
        }

        Console.WriteLine(removedKnights);
    }

    private static void FindAllKnights()
    {
        knights = new List<Knight>();
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (matrix[row][col] == 'K')
                {
                    knights.Add(new Knight(row, col));
                }
            }
        }
    }

    private static void CheckAllKnights()
    {
        foreach (var knight in knights)
        {
            knight.NumberOfKnightsToKill = 0;
        }

        foreach (var knight in knights)
        {
            var row = knight.Row;
            var col = knight.Col;
            if (row - 2 >= 0 && col - 1 >= 0 && matrix[row - 2][col - 1] == 'K')
            {
                knight.NumberOfKnightsToKill++;
            }
            if (row - 2 >= 0 && col + 1 < size && matrix[row - 2][col + 1] == 'K')
            {
                knight.NumberOfKnightsToKill++;
            }
            if (row + 2 < size && col - 1 >= 0 && matrix[row + 2][col - 1] == 'K')
            {
                knight.NumberOfKnightsToKill++;
            }
            if (row + 2 < size && col + 1 < size && matrix[row + 2][col + 1] == 'K')
            {
                knight.NumberOfKnightsToKill++;
            }
            if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1][col - 2] == 'K')
            {
                knight.NumberOfKnightsToKill++;
            }
            if (row - 1 >= 0 && col + 2 < size && matrix[row - 1][col + 2] == 'K')
            {
                knight.NumberOfKnightsToKill++;
            }
            if (row + 1 < size && col - 2 >= 0 && matrix[row + 1][col - 2] == 'K')
            {
                knight.NumberOfKnightsToKill++;
            }
            if (row + 1 < size && col + 2 < size && matrix[row + 1][col + 2] == 'K')
            {
                knight.NumberOfKnightsToKill++;
            }
        }
    }
}