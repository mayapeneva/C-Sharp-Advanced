using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_RadioactiveBunnies
{
    public class Bunnies
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var r = sizes[0];
            var c = sizes[1];

            var matrix = new char[r][];
            var playerRow = 0;
            var playerCol = 0;
            FindPlayer(r, c, matrix, ref playerRow, ref playerCol);

            var directions = Console.ReadLine().ToCharArray();
            for (int k = 0; k < directions.Length; k++)
            {
                if ((playerRow > 0 || playerRow < r - 1 || playerCol > 0 || playerCol < c - 1)
                    || (playerRow == 0 && directions[k] != 'L') || (playerRow == r - 1 && directions[k] != 'R')
                    || (playerCol == 0 && directions[k] != 'U') || (playerCol == c - 1 && directions[k] != 'D'))
                {
                    MovePlayer(matrix, ref playerRow, ref playerCol, directions, k);
                }

                ExpandBunnies(r, c, matrix);

                if (matrix[playerRow][playerCol] == 'B')
                {
                    ExpandBunnies(r, c, matrix);

                    PrintMatrix(matrix);

                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }

                if (playerRow <= 0 || playerRow >= r - 1 || playerCol <= 0 || playerCol >= c - 1)
                {
                    if (matrix[playerRow][playerCol] == 'P')
                    {
                        matrix[playerRow][playerCol] = '.';
                    }

                    ExpandBunnies(r, c, matrix);

                    PrintMatrix(matrix);

                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }
            }
        }

        private static void FindPlayer(int r, int c, char[][] matrix, ref int playerRow, ref int playerCol)
        {
            for (int i = 0; i < r; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
                if (matrix[i].Contains('P'))
                {
                    playerRow = i;
                    for (int j = 0; j < c; j++)
                    {
                        if (matrix[i][j] == 'P')
                        {
                            playerCol = j;
                        }
                    }
                }
            }
        }

        private static void MovePlayer(char[][] matrix, ref int playerRow, ref int playerCol, char[] directions, int k)
        {
            switch (directions[k])
            {
                case 'R':
                    matrix[playerRow][playerCol] = '.';
                    matrix[playerRow][playerCol + 1] = 'P';
                    playerCol++;
                    break;
                case 'L':
                    matrix[playerRow][playerCol] = '.';
                    matrix[playerRow][playerCol - 1] = 'P';
                    playerCol--;
                    break;
                case 'U':
                    matrix[playerRow][playerCol] = '.';
                    matrix[playerRow - 1][playerCol] = 'P';
                    playerRow--;
                    break;
                case 'D':
                    matrix[playerRow][playerCol] = '.';
                    matrix[playerRow + 1][playerCol] = 'P';
                    playerRow++;
                    break;
            }
        }

        private static void ExpandBunnies(int r, int c, char[][] matrix)
        {
            var bunnies = new List<int>();
            for (int rowIndex = 0; rowIndex < r; rowIndex++)
            {
                if (matrix[rowIndex].Contains('B'))
                {
                    for (int colIndex = 0; colIndex < c; colIndex++)
                    {
                        if (matrix[rowIndex][colIndex] == 'B')
                        {
                            bunnies.Add(rowIndex);
                            bunnies.Add(colIndex);
                        }

                    }
                }
            }

            for (int i = 0; i < bunnies.Count; i+=2)
            {
                ExpandInEachDirestion(matrix, bunnies[i], bunnies[i + 1] - 1, r, c);
                ExpandInEachDirestion(matrix, bunnies[i], bunnies[i + 1] + 1, r, c);
                ExpandInEachDirestion(matrix, bunnies[i] - 1, bunnies[i + 1], r, c);
                ExpandInEachDirestion(matrix, bunnies[i] + 1, bunnies[i + 1], r, c);
            }
        }

        private static void ExpandInEachDirestion(char[][] matrix, int rowIndex, int colIndex, int r, int c)
        {
            if (rowIndex >= 0 && rowIndex < r && colIndex >= 0 && colIndex < c)
            {
                matrix[rowIndex][colIndex] = 'B';
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var line in matrix)
            {
                Console.WriteLine(string.Join("", line));
            }
        }
    }
}
