using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var sizes = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var r = sizes[0];
        var c = sizes[1];

        var matrix = new char[r][];
        var playerRow = 0;
        var playerCol = 0;
        FillTheMatrixIn(r, matrix, ref playerRow, ref playerCol);

        var commands = Console.ReadLine().ToCharArray();
        var playerDead = false;
        var gameOver = false;
        for (int j = 0; j < commands.Length; j++)
        {
            switch (commands[j])
            {
                case 'L':
                    MoveLeft(matrix, playerRow, ref playerCol, ref playerDead, ref gameOver);
                    break;

                case 'R':
                    MoveRight(c, matrix, playerRow, ref playerCol, ref playerDead, ref gameOver);
                    break;

                case 'U':
                    MoveUp(matrix, ref playerRow, playerCol, ref playerDead, ref gameOver);
                    break;

                case 'D':
                    MoveDown(r, matrix, ref playerRow, playerCol, ref playerDead, ref gameOver);
                    break;
            }

            playerDead = BunniesAreSpreading(r, c, matrix, playerDead);

            if (gameOver)
            {
                break;
            }
        }

        for (int k = 0; k < r; k++)
        {
            Console.WriteLine(matrix[k]);
        }

        if (playerDead)
        {
            Console.WriteLine($"dead: {playerRow} {playerCol}");
        }
        else
        {
            Console.WriteLine($"won: {playerRow} {playerCol}");
        }
    }

    private static bool BunniesAreSpreading(int r, int c, char[][] matrix, bool playerDead)
    {
        var bunnies = new Queue<int>();
        for (int row = 0; row < r; row++)
        {
            for (int col = 0; col < c; col++)
            {
                if (matrix[row][col] == 'B')
                {
                    bunnies.Enqueue(row);
                    bunnies.Enqueue(col);
                }
            }
        }

        while (bunnies.Count > 0)
        {
            var rowIndex = bunnies.Dequeue();
            var colIndex = bunnies.Dequeue();

            if (rowIndex - 1 >= 0)
            {
                if (matrix[rowIndex - 1][colIndex] == 'P')
                {
                    playerDead = true;
                }

                matrix[rowIndex - 1][colIndex] = 'B';
            }
            if (rowIndex + 1 < r)
            {
                if (matrix[rowIndex + 1][colIndex] == 'P')
                {
                    playerDead = true;
                }

                matrix[rowIndex + 1][colIndex] = 'B';
            }
            if (colIndex - 1 >= 0)
            {
                if (matrix[rowIndex][colIndex - 1] == 'P')
                {
                    playerDead = true;
                }

                matrix[rowIndex][colIndex - 1] = 'B';
            }
            if (colIndex + 1 < c)
            {
                if (matrix[rowIndex][colIndex + 1] == 'P')
                {
                    playerDead = true;
                }

                matrix[rowIndex][colIndex + 1] = 'B';
            }
        }

        return playerDead;
    }

    private static void MoveDown(int r, char[][] matrix, ref int playerRow, int playerCol, ref bool playerDead, ref bool gameOver)
    {
        if (playerRow + 1 < r)
        {
            if (matrix[playerRow + 1][playerCol] != 'B')
            {
                matrix[playerRow + 1][playerCol] = 'P';
            }
            else
            {
                playerDead = true;
                gameOver = true;
            }

            matrix[playerRow][playerCol] = '.';
            playerRow++;
        }
        else
        {
            matrix[playerRow][playerCol] = '.';
            gameOver = true;
        }
    }

    private static void MoveUp(char[][] matrix, ref int playerRow, int playerCol, ref bool playerDead, ref bool gameOver)
    {
        if (playerRow - 1 >= 0)
        {
            if (matrix[playerRow - 1][playerCol] != 'B')
            {
                matrix[playerRow - 1][playerCol] = 'P';
            }
            else
            {
                playerDead = true;
                gameOver = true;
            }

            matrix[playerRow][playerCol] = '.';
            playerRow--;
        }
        else
        {
            matrix[playerRow][playerCol] = '.';
            gameOver = true;
        }
    }

    private static void MoveRight(int c, char[][] matrix, int playerRow, ref int playerCol, ref bool playerDead, ref bool gameOver)
    {
        if (playerCol + 1 < c)
        {
            if (matrix[playerRow][playerCol + 1] != 'B')
            {
                matrix[playerRow][playerCol + 1] = 'P';
            }
            else
            {
                playerDead = true;
                gameOver = true;
            }

            matrix[playerRow][playerCol] = '.';
            playerCol++;
        }
        else
        {
            matrix[playerRow][playerCol] = '.';
            gameOver = true;
        }
    }

    private static void MoveLeft(char[][] matrix, int playerRow, ref int playerCol, ref bool playerDead, ref bool gameOver)
    {
        if (playerCol - 1 >= 0)
        {
            if (matrix[playerRow][playerCol - 1] != 'B')
            {
                matrix[playerRow][playerCol - 1] = 'P';
            }
            else
            {
                playerDead = true;
                gameOver = true;
            }

            matrix[playerRow][playerCol] = '.';
            playerCol--;
        }
        else
        {
            matrix[playerRow][playerCol] = '.';
            gameOver = true;
        }
    }

    private static void FillTheMatrixIn(int r, char[][] matrix, ref int playerRow, ref int playerCol)
    {
        for (int i = 0; i < r; i++)
        {
            matrix[i] = Console.ReadLine().ToCharArray();
            if (matrix[i].Contains('P'))
            {
                playerCol = matrix[i].ToList().IndexOf('P');
                playerRow = i;
            }
        }
    }
}