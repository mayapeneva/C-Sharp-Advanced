using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var elementsToPush = parameters[0];
        var elementsToPop = parameters[1];
        var searchedElement = parameters[2];

        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var stack = new Stack<int>();
        for (int i = 0; i < elementsToPush; i++)
        {
            stack.Push(numbers[i]);
        }

        for (int j = 0; j < elementsToPop; j++)
        {
            stack.Pop();
        }

        if (stack.Contains(searchedElement))
        {
            Console.WriteLine("true");
        }
        else
        {
            if (stack.Count > 0)
            {
                Console.WriteLine(stack.ToArray().Min());
            }
            else
            {
                Console.WriteLine(stack.Count);
            }
        }
    }
}