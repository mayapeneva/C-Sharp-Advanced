using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Func<int, int, bool> divisible = (n, d) => n % d == 0;

        var lastNumber = int.Parse(Console.ReadLine());
        var dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var numbers = new List<int>();
        for (int i = 1; i <= lastNumber; i++)
        {
            var number = i;
            foreach (int divider in dividers)
            {
                if (!divisible(number, divider))
                {
                    number = Int32.MinValue;
                    break;
                }
            }

            if (number != int.MinValue)
            {
                numbers.Add(number);
            }
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}