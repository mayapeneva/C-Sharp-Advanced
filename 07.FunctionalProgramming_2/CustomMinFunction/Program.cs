using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Func<List<int>, int> smallest = l => l.Min();

        var list = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            .ToList();
        Console.WriteLine(smallest(list));
    }
}