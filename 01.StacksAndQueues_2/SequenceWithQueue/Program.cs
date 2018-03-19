using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var n = long.Parse(Console.ReadLine());
        var queue = new Queue<long>();

        long currentNumber = n;
        Console.Write($"{n} ");
        for (int i = 0; i < 16; i++)
        {
            var numOne = currentNumber + 1;
            queue.Enqueue(numOne);
            Console.Write($"{numOne} ");

            var numTwo = (2 * currentNumber) + 1;
            queue.Enqueue(numTwo);
            Console.Write($"{numTwo} ");

            var numThree = currentNumber + 2;
            queue.Enqueue(numThree);
            Console.Write($"{numThree} ");

            currentNumber = queue.Dequeue();
        }

        Console.WriteLine(currentNumber + 1);
    }
}