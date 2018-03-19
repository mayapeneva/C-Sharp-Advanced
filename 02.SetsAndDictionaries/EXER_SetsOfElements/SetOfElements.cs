using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_SetsOfElements
{
    public class SetOfElements
    {
        public static void Main()
        {
            var counts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var firstSet = new HashSet<string>();
            for (int i = 0; i < counts[0]; i++)
            {
                firstSet.Add(Console.ReadLine());
            }

            var result = new HashSet<string>();
            for (int i = 0; i < counts[1]; i++)
            {
                var element = Console.ReadLine();
                if (firstSet.Contains(element))
                {
                    result.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
