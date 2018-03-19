using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var stack = new Stack<long>();
        stack.Push(0);
        long firstNumber = 1;
        for (int i = 0; i < n; i++)
        {
            long currentNumber = stack.Peek();
            stack.Push(currentNumber + firstNumber);
            firstNumber = currentNumber;
        }

        Console.WriteLine(stack.Peek());
    }
}