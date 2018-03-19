using System;
using System.Linq;

namespace EXER_RubiksMatrix
{
    public class Rubiks
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var r = sizes[0];
            var c = sizes[1];

            var matrix = new int[r][];
            var number = 1;
            for (int row = 0; row < r; row++)
            {
                matrix[row] = new int[c];
                for (int col = 0; col < c; col++)
                {
                    matrix[row][col] = number;
                    number++;
                }
            }

            var commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                var command = Console.ReadLine().Split();
                var direction = command[1];
                var rowOrCol = int.Parse(command[0]);
                var step = int.Parse(command[2]);
                switch (direction)
                {
                    case "up": SwapNumbersUp(matrix, rowOrCol, step);
                        break;
                    case "down": SwapNumbersDown(matrix, rowOrCol, step);
                            break;
                    case "left": SwapNumbersLeft(matrix, rowOrCol, step);
                        break;
                    case "right": SwapNumbersRight(matrix, rowOrCol, step);
                        break;
                }
            }

            number = 1;
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == number)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        SwapNumbersBack(matrix, number, rowIndex, colIndex);
                    }
                    number++;
                }
            }
        }

        private static void SwapNumbersBack(int[][] matrix, int number, int rowIndex, int colIndex)
        {
            for (int swapRow = rowIndex; swapRow < matrix.Length; swapRow++)
            {
                for (int swapCol = 0; swapCol < matrix[swapRow].Length; swapCol++)
                {
                    if (matrix[swapRow][swapCol] == number)
                    {
                        matrix[swapRow][swapCol] = matrix[rowIndex][colIndex];
                        matrix[rowIndex][colIndex] = number;
                        Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({swapRow}, {swapCol})” ");
                        break;
                    }
                }

                if (matrix[rowIndex][colIndex] == number)
                {
                    break;
                }
            }
        }

        private static void SwapNumbersDown(int[][] matrix, int rowOrCol, int step)
        {
            for (int k = 0; k < step % matrix.Length; k++)
            {
                var tempNumber = matrix[matrix.Length - 1][rowOrCol];
                for (int rowIndex = matrix.Length - 1; rowIndex > 0; rowIndex--)
                {
                    matrix[rowIndex][rowOrCol] = matrix[rowIndex - 1][rowOrCol];

                }
                matrix[0][rowOrCol] = tempNumber;
            }
        }

        private static void SwapNumbersUp(int[][] matrix, int rowOrCol, int step)
        {
            for (int j = 0; j < step % matrix.Length; j++)
            {
                var tempNumber = matrix[0][rowOrCol];
                for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
                {
                    matrix[rowIndex][rowOrCol] = matrix[rowIndex + 1][rowOrCol];

                }
                matrix[matrix.Length - 1][rowOrCol] = tempNumber;
            }
        }

        private static void SwapNumbersRight(int[][] matrix, int rowOrCol, int step)
        {
            for (int k = 0; k < step % matrix[rowOrCol].Length; k++)
            {
                var tempNumber = matrix[rowOrCol][matrix[rowOrCol].Length - 1];
                for (int colIndex = matrix[rowOrCol].Length - 1; colIndex > 0; colIndex--)
                {
                    matrix[rowOrCol][colIndex] = matrix[rowOrCol][colIndex - 1];

                }
                matrix[rowOrCol][0] = tempNumber;
            }
        }

        private static void SwapNumbersLeft(int[][] matrix, int rowOrCol, int step)
        {
            for (int j = 0; j < step % matrix[rowOrCol].Length; j++)
            {
                var tempNumber = matrix[rowOrCol][0];
                for (int colIndex = 0; colIndex < matrix[rowOrCol].Length - 1; colIndex++)
                {
                    matrix[rowOrCol][colIndex] = matrix[rowOrCol][colIndex + 1];

                }
                matrix[rowOrCol][matrix[rowOrCol].Length - 1] = tempNumber;
            }
        }
    }
}
