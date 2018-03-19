using System;
using System.Linq;

namespace LAB_SortEvenNumbers
{
    public class SortEvenNumbers
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .ToList()
                .OrderBy(n => n)));
        }
    }
}
