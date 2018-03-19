using System;
using System.Linq;

namespace LAB_BoundedNumbers
{
    public class Boundedn
    {
        public static void Main()
        {
            var bounders = Console.ReadLine().Split().Select(int.Parse);
            Console.WriteLine(string.Join(" ", Console.ReadLine().Split().Select(int.Parse).Where(n => n >= bounders.Min() && n <= bounders.Max())));
        }
    }
}
