using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var rube = new int[n, n, n];

        var changedCells = 0;
        string input;
        while ((input = Console.ReadLine()) != "Analyze")
        {
            var args = input.Split().Select(int.Parse).ToArray();
            var row = args[0];
            var col = args[1];
            var height = args[2];
            if (CellExists(row, col, height, n))
            {
                rube[row, col, height] = args[3];
            }
        }

        long sum = 0;
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                for (int h = 0; h < n; h++)
                {
                    if (rube[r, c, h] != 0)
                    {
                        sum += rube[r, c, h];
                        changedCells++;
                    }
                }
            }
        }

        Console.WriteLine(sum);
        Console.WriteLine(Math.Pow(n, 3) - changedCells);
    }

    private static bool CellExists(int row, int col, int height, int n)
    {
        return (row >= 0 && row < n && col >= 0 && col < n
                && height >= 0 && height < n);
    }
}