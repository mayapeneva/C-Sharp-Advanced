using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB_CountSameValuesInArray
{
    public class CountValues
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            var result = new SortedDictionary<double, int>();
            for (int i = 0; i < input.Length; i++)
            {
                var number = input[i];
                if (!result.ContainsKey(number))
                {
                    result[number] = 0;
                }

                result[number]++;
            }

            foreach (var num in result)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
