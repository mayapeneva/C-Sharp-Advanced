using System;
using System.Linq;

namespace LAB_SumNumbers
{
    public class SumNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(input.Count);
            Console.WriteLine(input.Sum());
        }
    }
}
