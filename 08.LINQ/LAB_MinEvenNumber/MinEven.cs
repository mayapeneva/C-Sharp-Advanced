using System;
using System.Linq;

namespace LAB_MinEvenNumber
{
    public class MinEven
    {
        public static void Main()
        {
            var result = Console.ReadLine().Split().Select(double.Parse).Where(n => n % 2 == 0).ToArray();
            if (result.Length > 0)
            {
                Console.WriteLine($"{result.Min():f2}");
                return;
            }

            Console.WriteLine("No match");
        }

    }
}
