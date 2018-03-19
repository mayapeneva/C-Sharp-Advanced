using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_BasicQueueOperations
{
    public class QueueOpers
    {
        public static void Main()
        {
            var operators = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>();
            for (int i = 0; i < operators[0]; i++)
            {
                queue.Enqueue(input[i]);
            }

            for (int j = 0; j < operators[1]; j++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(operators[2]))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
