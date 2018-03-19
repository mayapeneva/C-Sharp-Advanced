namespace LAB_MathPotato
{
    using System;
    using System.Collections.Generic;

    public class MathPotato
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(input);
            var cycle = 1;
            while (queue.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                if (IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {queue.Peek()}"); 
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }

                cycle++;
            }

            Console.WriteLine($"Last is {queue.Peek()}");
        }

        private static bool IsPrime(int number)
        {
            if ((number & 1) == 0)
            {
                if (number == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            for (int i = 3; (i * i) <= number; i += 2)
            {
                if ((number % i) == 0)
                {
                    return false;
                }
            }

            return number != 1;
        }
    }
}
