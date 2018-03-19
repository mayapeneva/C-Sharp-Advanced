using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var plants = Console.ReadLine().Split().Select(int.Parse).ToList();

        var plantsCount = 0;
        var days = 0;
        while (plantsCount != plants.Count)
        {
            plantsCount = plants.Count;
            var plantsToRemove = new Stack<int>();
            for (int i = 1; i < plants.Count; i++)
            {
                var currentPlant = plants[i - 1];
                if (currentPlant < plants[i])
                {
                    plantsToRemove.Push(i);
                }
            }

            while (plantsToRemove.Count > 0)
            {
                plants.RemoveAt(plantsToRemove.Pop());
            }
            days++;
        }

        Console.WriteLine(days - 1);
    }
}