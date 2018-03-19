using System;
using System.Linq;
using System.Text;

namespace EXER_MatrixOfPalindromes
{
    public class Palindromes
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var r = sizes[0];
            var c = sizes[1];

            var matrix = new string[r][];
            for (int row = 0; row < r; row++)
            {
                matrix[row] = new string[c];
                var stringToAdd = new StringBuilder();
                for (int col = 0; col < c; col++)
                {
                    stringToAdd.Append($"{(char) (97 + row)}{(char) (97 + row + col)}{(char) (97 + row)} ");
                }
                matrix[row] = stringToAdd.ToString().Trim().Split();
            }

            foreach (var matrixRow in matrix)
            {
                Console.WriteLine(string.Join(" ", matrixRow));
            }
        }
    }
}
