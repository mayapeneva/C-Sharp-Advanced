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
        var queue = new Queue<int>();
        for (int i = 0; i < elementsToPush; i++)
        {
            queue.Enqueue(numbers[i]);
        }

        for (int j = 0; j < elementsToPop; j++)
        {
            queue.Dequeue();
        }

        if (queue.Contains(searchedElement))
        {
            Console.WriteLine("true");
        }
        else
        {
            if (queue.Count > 0)
            {
                Console.WriteLine(queue.ToArray().Min());
            }
            else
            {
                Console.WriteLine(queue.Count);
            }
        }
    }
}