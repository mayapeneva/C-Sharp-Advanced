using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();
        var stack = new Stack<string>(input);
        while (stack.Count > 0)
        {
            Console.Write($"{stack.Pop()} ");
        }
        Console.WriteLine();
    }
}