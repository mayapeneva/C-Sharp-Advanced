using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_Crossfire
{
    public class Crossfire
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            var r = sizes[0];
            var c = sizes[1];

            var matrix = new List<List<int>>();
            var number = 1;
            for (int rIndex = 0; rIndex < r; rIndex++)
            {
                matrix.Add(new List<int>());
                for (int cIndex = 0; cIndex < c; cIndex++)
                {
                    matrix[rIndex].Add(number);
                    number++;
                }
            }

            var command = Console.ReadLine();
            while (command != "Nuke it from orbit")
            {
                var crossfire = command.Split().Select(int.Parse).ToArray();
                var fireRow = crossfire[0];
                var fireCol = crossfire[1];
                var fireRadius = crossfire[2];

                var startCol = fireCol - fireRadius;
                var endCol = fireCol + fireRadius;
                var startRow = fireRow - fireRadius;
                var endRow = fireRow + fireRadius;
                if (fireRow >= 0 && fireRow < matrix.Count
                    && fireCol >= 0 && fireCol < matrix[fireRow].Count)
                {
                    if (startCol < 0)
                    {
                        startCol = 0;
                    }

                    if (endCol > matrix[fireRow].Count - 1)
                    {
                        endCol = matrix[fireRow].Count - 1;
                    }

                    if (startRow < 0)
                    {
                        startRow = 0;
                    }

                    if (endRow > matrix.Count - 1)
                    {
                        endRow = matrix.Count - 1;
                    }

                    DestroyingCellsVertically(matrix, ref fireRow, startCol, endCol, ref endRow);

                    DestroyingCellsHorisontally(matrix, fireRow, fireCol, startRow, endRow);
                }
                else if (fireCol >= 0 && fireCol < c)
                {
                    if (startRow < matrix.Count)
                    {
                        endRow = matrix.Count - 1;
                    }
                    else if (endRow >= 0)
                    {
                        startRow = 0;
                    }

                    fireRow = -1;
                    DestroyingCellsHorisontally(matrix, fireRow, fireCol, startRow, endRow);
                }
                else if (fireRow >= 0 && fireRow < matrix.Count)
                {
                    if (startCol < matrix[fireRow].Count)
                    {
                        endCol = matrix[fireRow].Count - 1;
                    }
                    else if (endCol >= 0)
                    {
                        startCol = 0;
                    }

                    DestroyingCellsVertically(matrix, ref fireRow, startCol, endCol, ref endRow);
                }

                command = Console.ReadLine();
            }

            foreach (var resultLine in matrix)
            {
                Console.WriteLine(string.Join(" ", resultLine));
            }
        }

        private static void DestroyingCellsHorisontally(List<List<int>> matrix, int fireRow, int fireCol, int startRow, int endRow)
        {
            for (int i = endRow; i >= startRow; i--)
            {
                if (i != fireRow && matrix[i].Count > fireCol)
                {
                    matrix[i].RemoveAt(fireCol);
                }
            }
        }

        private static void DestroyingCellsVertically(List<List<int>> matrix, ref int fireRow, int startCol, int endCol, ref int endRow)
        {
            if (startCol == 0 && endCol - startCol + 1 >= matrix[fireRow].Count)
            {
                matrix.RemoveAt(fireRow);
                endRow--;
                fireRow = int.MaxValue;
            }
            else if (matrix[fireRow].Count >= endCol + 1)
            {
                matrix[fireRow].RemoveRange(startCol, endCol - startCol + 1);
            }
        }
    }
}
