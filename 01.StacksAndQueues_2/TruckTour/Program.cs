using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var pumps = new Queue<List<int>>();
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();
            pumps.Enqueue(input);
        }

        long tank = 0;
        var index = 0;
        for (int i = 0; i < n; i++)
        {
            var currentPump = pumps.Dequeue();
            var currentPumpFuel = currentPump[0];
            var distanceToNextPump = currentPump[1];
            pumps.Enqueue(currentPump);

            if (tank + currentPumpFuel >= distanceToNextPump)
            {
                tank += currentPumpFuel;
                tank -= distanceToNextPump;
            }
            else
            {
                tank = 0;
                index = i + 1;
            }
        }

        Console.WriteLine(index);
    }
}