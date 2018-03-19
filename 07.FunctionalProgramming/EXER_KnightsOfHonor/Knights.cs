using System;
using System.Linq;

namespace EXER_KnightsOfHonor
{
    public class Knights
    {
        public static void Main()
        {
            Action<string> print = w => Console.WriteLine($"Sir {w}");

            Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList().ForEach(print);
        }
    }
}
