using System;
using System.Linq;

namespace EXER_SquaresInMatrix
{
    public class Squares
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var r = sizes[0];

            var matrix = new string[r][];
            for (int i = 0; i < r; i++)
            {
                matrix[i] = Console.ReadLine().Split();
            }

            var counter = 0;
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {

                    var symbol = matrix[row][col];
                    if (matrix[row][col + 1] == symbol && matrix[row + 1][col] == symbol
                        && matrix[row + 1][col + 1] == symbol)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
