using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Func<List<int>, int, List<int>> removeDivisible = (l, d) => l.Where(n => n % d != 0).ToList();
        Action<List<int>> reverse = l => l.Reverse();

        var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        var divider = int.Parse(Console.ReadLine());

        reverse(numbers);

        Console.WriteLine(string.Join(" ", removeDivisible(numbers, divider)));
    }
}