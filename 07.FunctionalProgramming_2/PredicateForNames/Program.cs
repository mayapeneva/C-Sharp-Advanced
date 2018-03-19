using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Func<string, int, bool> shorter = (s, l) => s.Length <= l;

        var length = int.Parse(Console.ReadLine());
        var names = Console.ReadLine().Split().ToList();
        names.Where(n => shorter(n, length)).ToList().ForEach(n => Console.WriteLine(n));
    }
}