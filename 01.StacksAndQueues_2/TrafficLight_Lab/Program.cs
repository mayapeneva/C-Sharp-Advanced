using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var carQueue = new Queue<string>();
        var passedCarsCount = 0;

        var input = Console.ReadLine();
        while (input != "end")
        {
            if (input == "green")
            {
                for (int i = 0; i < n; i++)
                {
                    if (carQueue.Count > 0)
                    {
                        Console.WriteLine($"{carQueue.Dequeue()} passed!");
                        passedCarsCount++;
                    }
                }
            }
            else
            {
                carQueue.Enqueue(input);
            }

            input = Console.ReadLine();
        }

        Console.WriteLine($"{passedCarsCount} cars passed the crossroads.");
    }
}