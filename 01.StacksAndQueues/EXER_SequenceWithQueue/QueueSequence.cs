using System;
using System.Collections.Generic;

namespace EXER_SequenceWithQueue
{
    public class QueueSequence
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            long element = n;
            var result = new Queue<long>();
            result.Enqueue(n);
            for (int i = 0; i < 16; i++)
            {
                queue.Enqueue(element + 1);
                queue.Enqueue(2 * element + 1);
                queue.Enqueue(element + 2);

                element = queue.Peek();
                result.Enqueue(queue.Dequeue());
            }

            queue.Enqueue(element + 1);

            while (result.Count > 0)
            {
                Console.Write($"{result.Dequeue()} ");
            }

            while (queue.Count > 1)
            {
                Console.Write($"{queue.Dequeue()} ");
            }

            Console.Write(queue.Dequeue());
            Console.WriteLine();
        }
    }
}
