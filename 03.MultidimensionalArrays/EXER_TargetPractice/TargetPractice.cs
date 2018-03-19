using System;
using System.Linq;

namespace EXER_TargetPractice
{
    public class TargetPractice
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var snake = Console.ReadLine().ToCharArray();
            var matrix = new char[sizes[0]][];

            FillTheMatrixInWithSnake(sizes, snake, matrix);

            var shot = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var impactRow = shot[0];
            var impactCol = shot[1];
            var radius = shot[2];

            ShootTheSnake(matrix, impactRow, impactCol, radius);

            SymbolsFallingDown(sizes[1], matrix);

            foreach (var line in matrix)
            {
                Console.WriteLine(string.Join("", line));
            }
        }

        private static void SymbolsFallingDown(int colSize, char[][] matrix)
        {
            for (int c = 0; c < colSize; c++)
            {
                for (int r = matrix.Length - 1; r > 0; r--)
                {
                    if (matrix[r][c] == ' ')
                    {
                        for (int i = r - 1; i >= 0; i--)
                        {
                            if (matrix[i][c] != ' ')
                            {
                                matrix[r][c] = matrix[i][c];
                                matrix[i][c] = ' ';
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void ShootTheSnake(char[][] matrix, int impactRow, int impactCol, int radius)
        {
            var index = 0;
            for (int row = impactRow - radius; row <= impactRow; row++)
            {
                if (row < 0)
                {
                    row = 0;
                }

                for (int col = impactCol - index; col <= impactCol + index; col++)
                {
                    if (col < 0)
                    {
                        col = 0;
                    }
                    else if (col > matrix[row].Length - 1)
                    {
                        break;
                    }

                    matrix[row][col] = ' ';
                }
                index++;
            }

            index -= 2;
            for (int row = impactRow + 1; row <= impactRow + radius; row++)
            {
                if (row > matrix.Length - 1)
                {
                    break;
                }

                for (int col = impactCol - index; col <= impactCol + index; col++)
                {
                    if (col < 0)
                    {
                        col = 0;
                    }
                    else if (col > matrix[row].Length - 1)
                    {
                        break;
                    }

                    matrix[row][col] = ' ';
                }
                index--;
            }
        }

        private static void FillTheMatrixInWithSnake(int[] sizes, char[] snake, char[][] matrix)
        {
            var index = 0;
            for (int rowIndex = sizes[0] - 1; rowIndex >= 0; rowIndex--)
            {
                matrix[rowIndex] = new char[sizes[1]];
                if (rowIndex % 2 == (sizes[0] - 1) % 2)
                {
                    for (int colIndex = sizes[1] - 1; colIndex >= 0; colIndex--)
                    {
                        matrix[rowIndex][colIndex] = snake[index];
                        index++;
                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                    }
                }
                else
                {
                    for (int colIndex = 0; colIndex < sizes[1]; colIndex++)
                    {
                        matrix[rowIndex][colIndex] = snake[index];
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
}
