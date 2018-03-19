using System;
using System.Linq;

namespace LAB_UpperStrings
{
    public class UpperStrings
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split()
                .Select(w => w.ToUpper())
                .ToList()
                .ForEach(w => Console.Write($"{w} "));
            Console.WriteLine();
        }
    }
}
