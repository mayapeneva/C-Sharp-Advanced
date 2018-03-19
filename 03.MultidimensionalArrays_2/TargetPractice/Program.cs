using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var sizes = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var r = sizes[0];
        var c = sizes[1];
        var matrix = new char[r, c];

        var snake = Console.ReadLine().ToCharArray();
        FillTheMatrixIn(r, c, matrix, snake);

        var shotParams = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        ShootTheSnake(r, c, matrix, shotParams);

        ShakeTheLeftOversDown(r, c, matrix);

        for (int rIndex = 0; rIndex < r; rIndex++)
        {
            for (int cIndex = 0; cIndex < c; cIndex++)
            {
                Console.Write(matrix[rIndex, cIndex]);
            }

            Console.WriteLine();
        }
    }

    private static void ShakeTheLeftOversDown(int r, int c, char[,] matrix)
    {
        for (int colIndex = 0; colIndex < c; colIndex++)
        {
            var emptyRows = 0;
            for (int rowIndex = r - 1; rowIndex >= 0; rowIndex--)
            {
                if (matrix[rowIndex, colIndex] == ' ')
                {
                    emptyRows++;
                }
                else if (emptyRows > 0)
                {
                    matrix[rowIndex + emptyRows, colIndex] = matrix[rowIndex, colIndex];
                    matrix[rowIndex, colIndex] = ' ';
                }
            }
        }
    }

    private static void ShootTheSnake(int r, int c, char[,] matrix, int[] shotParams)
    {
        var impactRow = shotParams[0];
        var impactCol = shotParams[1];
        var radius = shotParams[2];

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                var a = impactRow - i;
                var b = impactCol - j;
                var distance = Math.Sqrt(a * a + b * b);
                if (distance <= radius)
                {
                    matrix[i, j] = ' ';
                }
            }
        }
    }

    private static void FillTheMatrixIn(int r, int c, char[,] matrix, char[] snake)
    {
        var index = 0;
        for (int row = r - 1; row >= 0; row--)
        {
            if ((r % 2 == 0 && row % 2 != 0)
                || (r % 2 != 0 && row % 2 == 0))
            {
                for (int col = c - 1; col >= 0; col--)
                {
                    matrix[row, col] = snake[index];
                    index++;

                    if (index == snake.Length)
                    {
                        index = 0;
                    }
                }
            }
            else
            {
                for (int col = 0; col < c; col++)
                {
                    matrix[row, col] = snake[index];
                    index++;

                    if (index == snake.Length)
                    {
                        index = 0;
                    }
                }
            }
        }
    }
}