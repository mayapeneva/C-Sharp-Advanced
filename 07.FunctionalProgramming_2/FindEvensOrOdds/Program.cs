using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Predicate<int> even = n => n % 2 == 0;
        Action<int> print = n => Console.Write($"{n} ");

        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var start = input[0];
        var end = input[1];

        var condition = Console.ReadLine();
        for (int i = start; i <= end; i++)
        {
            if ((condition == "even" && even(i))
                || condition == "odd" && !even(i))
            {
                print(i);
            }
        }

        Console.WriteLine();
    }
}