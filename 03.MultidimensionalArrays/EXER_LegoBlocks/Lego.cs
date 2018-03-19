using System;
using System.Linq;

namespace EXER_LegoBlocks
{
    public class Lego
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var firstMatrix = new int[n][];
            FillMatrixIn(n, firstMatrix);

            var secondMatrix = new int[n][];
            FillMatrixIn(n, secondMatrix);

            var colsNumber = firstMatrix[0].Length + secondMatrix[0].Length;
            var ifFits = true;
            for (int rows = 1; rows < n; rows++)
            {
                if (firstMatrix[rows].Length + secondMatrix[rows].Length != colsNumber)
                {
                    ifFits = false;
                    break;
                }
            }

            if (ifFits)
            {
                var theMatrix = new int[n][];
                FitsTheTwoMatrixes(n, firstMatrix, secondMatrix, colsNumber, theMatrix);

                foreach (var line in theMatrix)
                {
                    Console.WriteLine($"[{string.Join(", ", line)}]");
                }
            }
            else
            {
                var firstCellsCount = CountCellsInMatrix(firstMatrix);
                var secondCellsCount = CountCellsInMatrix(secondMatrix);
                Console.WriteLine($"The total number of cells is: {firstCellsCount + secondCellsCount}");
            }
        }

        private static int CountCellsInMatrix(int[][] firstMatrix)
        {
            var cellsCount = 0;
            foreach (var row in firstMatrix)
            {
                cellsCount += row.Length;
            }

            return cellsCount;
        }

        private static void FitsTheTwoMatrixes(int n, int[][] firstMatrix, int[][] secondMatrix, int colsNumber, int[][] theMatrix)
        {
            for (int r = 0; r < n; r++)
            {
                theMatrix[r] = new int[colsNumber];
                int c1;
                for (c1 = 0; c1 < firstMatrix[r].Length; c1++)
                {
                    theMatrix[r][c1] = firstMatrix[r][c1];
                }

                for (int c2 = secondMatrix[r].Length - 1; c2 >= 0; c2--)
                {
                    theMatrix[r][c1] = secondMatrix[r][c2];
                    c1++;
                }
            }
        }

        private static void FillMatrixIn(int n, int[][] firstMatrix)
        {
            for (int i = 0; i < n; i++)
            {
                firstMatrix[i] = Console.ReadLine().Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }
        }
    }
}
