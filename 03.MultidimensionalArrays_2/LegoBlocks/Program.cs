using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var firstArray = new int[n][];
        for (int i = 0; i < n; i++)
        {
            firstArray[i] = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }

        var secondArray = new int[n][];
        for (int j = 0; j < n; j++)
        {
            secondArray[j] = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).Reverse().ToArray();
        }

        var resultColNum = firstArray[0].Length + secondArray[0].Length;
        for (int k = 1; k < n; k++)
        {
            if (firstArray[k].Length + secondArray[k].Length != resultColNum)
            {
                var cellsCount = 0;
                for (int l = 0; l < n; l++)
                {
                    cellsCount += firstArray[l].Length + secondArray[l].Length;
                }

                Console.WriteLine($"The total number of cells is: {cellsCount}");
                return;
            }
        }

        for (int m = 0; m < n; m++)
        {
            Console.WriteLine('[' + string.Join(", ", firstArray[m]) + ", " + string.Join(", ", secondArray[m]) + ']');
        }
    }
}