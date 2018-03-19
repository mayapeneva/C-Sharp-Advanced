using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Func<char, int> converter = c => (int)c;
        Func<string, int, Func<char, int>, bool> equalSum = (n, b, f) => n.ToCharArray().Select(c => f(c)).Sum() >= b;

        var border = int.Parse(Console.ReadLine());
        var names = Console.ReadLine().Split().ToList();

        var name = names.FirstOrDefault(n => equalSum(n, border, converter));
        Console.WriteLine(name);
    }
}