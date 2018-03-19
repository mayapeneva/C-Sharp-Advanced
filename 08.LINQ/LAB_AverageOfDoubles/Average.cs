using System;
using System.Linq;

namespace LAB_AverageOfDoubles
{
    public class Average
    {
        public static void Main()
        {
            Console.WriteLine($"{Console.ReadLine().Split().Select(double.Parse).Average():f2}");

        }
    }
}
