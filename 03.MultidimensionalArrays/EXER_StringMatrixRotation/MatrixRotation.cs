using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_StringMatrixRotation
{
    public class MatrixRotation
    {
        public static void Main()
        {
            var command = Console.ReadLine().Split(new[] { "(" }, StringSplitOptions.RemoveEmptyEntries);
            var rotationDegrees = int.Parse(command[command.Length - 1].Trim(')'));

            var matrix = new List<List<char>>();
            var stringLine = Console.ReadLine();
            var maxLength = 0;
            while (stringLine != "END")
            {
                if (stringLine.Length > maxLength)
                {
                    maxLength = stringLine.Length;
                }
                matrix.Add(stringLine.ToList());

                stringLine = Console.ReadLine();
            }
            // result should be and Array, not List!!!
            var result = new List<List<char>>();
            var newLength = matrix.Count > maxLength ? matrix.Count : maxLength;
            for (int i = 0; i < newLength; i++)
            {
                result.Add(new List<char>());
            }
            var index = matrix.Count - 1;

            var rotation = rotationDegrees / 90;
            if (rotation == 1 || rotation - 1 % 3 == 0)
            {
                for (int row = 0; row < matrix.Count; row++)
                {
                    var lineToRotate = matrix[row];
                    for (int j = 0; j < lineToRotate.Count; j++)
                    {
                        result[j][index] = lineToRotate[j];
                    }

                    index--;
                }
            }
            else if (rotation == 2 || rotation - 2 % 3 == 0)
            {
                for (int row = 0; row < matrix.Count; row++)
                {
                    var lineToRotate = matrix[row];
                    var colIndex = maxLength;
                    for (int k = 0; k < lineToRotate.Count; k++)
                    {
                        result[index][colIndex] = lineToRotate[k];
                    }

                    index--;
                    colIndex--;
                }
            }
            else
            {
                index = maxLength;
                for (int row = 0; row < matrix.Count; row++)
                {
                    var lineToRotate = matrix[row];
                    for (int l = 0; l < lineToRotate.Count; l++)
                    {
                        result[index][row] = lineToRotate[l];
                    }

                    index--;
                }
            }

            foreach (var line in matrix)
            {
                Console.WriteLine(string.Join(" ", line));
            }
        }
    }
}