using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_CustomComparator
{
    public class Comparator
    {
        public static void Main()
        {
            Predicate<int> evens = n => n % 2 == 0;
            Action<List<int>> sorter = l => l.Sort();

            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var evenNumbers = new List<int>();
            var oddNumbers = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                var num = input[i];
                if (evens(num))
                {
                    evenNumbers.Add(num);
                }
                else
                {
                    oddNumbers.Add(num);
                }
            }

            sorter(evenNumbers);
            Console.Write($"{string.Join(" ", evenNumbers)} ");
            sorter(oddNumbers);
            Console.WriteLine(string.Join(" ", oddNumbers));
        }
    }
}
