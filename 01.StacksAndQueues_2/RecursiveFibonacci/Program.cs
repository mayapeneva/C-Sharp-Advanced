using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var list = new List<long> { 1, 1 };
        for (int i = 2; i < n; i++)
        {
            list.Add(list[i - 1] + list[i - 2]);
        }

        Console.WriteLine(list[n - 1]);
    }
}