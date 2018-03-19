using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = sizes[0];
        var c = sizes[1];

        var matrix = new int[r, c];
        FillMatrixIn(r, c, matrix);

        var n = int.Parse(Console.ReadLine());
        ExecutingCommands(r, c, matrix, n);

        SwapCellsBack(r, c, matrix);
    }

    private static void SwapCellsBack(int r, int c, int[,] matrix)
    {
        var number = 1;
        for (int row = 0; row < r; row++)
        {
            for (int col = 0; col < c; col++)
            {
                if (matrix[row, col] == number)
                {
                    Console.WriteLine("No swap required");
                }
                else
                {
                    for (int rowIndex = row; rowIndex < r; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < c; colIndex++)
                        {
                            if (matrix[rowIndex, colIndex] == number)
                            {
                                matrix[rowIndex, colIndex] = matrix[row, col];
                                matrix[row, col] = number;
                                Console.WriteLine($"Swap ({row}, {col}) with ({rowIndex}, {colIndex})");
                                break;
                            }
                        }

                        if (matrix[row, col] == number)
                        {
                            break;
                        }
                    }
                }
                number++;
            }
        }
    }

    private static void ExecutingCommands(int r, int c, int[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            var command = Console.ReadLine().Split();
            var rOrC = int.Parse(command[0]);
            var direction = command[1];
            var times = int.Parse(command[2]);
            switch (direction)
            {
                case "up":
                    for (int j = 0; j < times % r; j++)
                    {
                        var current = matrix[0, rOrC];
                        for (int k = 0; k < r - 1; k++)
                        {
                            matrix[k, rOrC] = matrix[k + 1, rOrC];
                        }
                        matrix[r - 1, rOrC] = current;
                    }
                    break;

                case "down":
                    for (int j = 0; j < times % r; j++)
                    {
                        var current = matrix[r - 1, rOrC];
                        for (int k = r - 1; k > 0; k--)
                        {
                            matrix[k, rOrC] = matrix[k - 1, rOrC];
                        }
                        matrix[0, rOrC] = current;
                    }
                    break;

                case "left":
                    for (int j = 0; j < times % c; j++)
                    {
                        var current = matrix[rOrC, 0];
                        for (int k = 0; k < c - 1; k++)
                        {
                            matrix[rOrC, k] = matrix[rOrC, k + 1];
                        }
                        matrix[rOrC, c - 1] = current;
                    }
                    break;

                case "right":
                    for (int j = 0; j < times % c; j++)
                    {
                        var current = matrix[rOrC, c - 1];
                        for (int k = c - 1; k > 0; k--)
                        {
                            matrix[rOrC, k] = matrix[rOrC, k - 1];
                        }
                        matrix[rOrC, 0] = current;
                    }
                    break;
            }
        }
    }

    private static void FillMatrixIn(int r, int c, int[,] matrix)
    {
        var number = 1;
        for (int row = 0; row < r; row++)
        {
            for (int col = 0; col < c; col++)
            {
                matrix[row, col] = number;
                number++;
            }
        }
    }
}