using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var size = int.Parse(Console.ReadLine());
        var matrix = new int[size][];

        for (int r = 0; r < size; r++)
        {
            matrix[r] = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        }

        var primaryDiagonalSum = 0;
        var secondaryDiagonalSum = 0;
        var index = size - 1;
        for (int i = 0; i < size; i++)
        {
            primaryDiagonalSum += matrix[i][i];
            secondaryDiagonalSum += matrix[i][index];
            index--;
        }

        Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
    }
}