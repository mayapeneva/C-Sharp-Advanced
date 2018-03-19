using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var command = query[0];
            if (command == 1)
            {
                stack.Push(query[1]);
            }
            else if (command == 2)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            else
            {
                Console.WriteLine(stack.OrderBy(x => x).ToArray()[stack.Count - 1]);
            }
        }
    }
}