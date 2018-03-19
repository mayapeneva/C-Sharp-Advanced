using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Action<string> print = s => Console.WriteLine(s);

        Console.ReadLine().Split().ToList().ForEach(print);
    }
}