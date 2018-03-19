using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Action<string> print = s => Console.WriteLine($"Sir {s}");

        Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(print);
    }
}