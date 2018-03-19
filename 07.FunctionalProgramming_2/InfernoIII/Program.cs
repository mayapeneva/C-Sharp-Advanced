using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Func<int, int, bool> equals = (a, b) => a == b;

        var gems = Console.ReadLine().Split().Select(int.Parse).ToList();
        gems.Insert(0, 0);
        gems.Add(0);

        var commands = new List<string>();
        ReadCommands(commands);

        var toBeExcluded = new SortedSet<int>();
        foreach (var command in commands)
        {
            var com = command.Split(';').ToArray();
            var condition = com[1];
            var border = int.Parse(com[2]);

            switch (condition)
            {
                case "Sum Left":
                    SumLeft(gems, toBeExcluded, border, equals);
                    break;

                case "Sum Right":
                    SumRight(gems, toBeExcluded, border, equals);
                    break;

                case "Sum Left Right":
                    SumLeftRight(gems, toBeExcluded, border, equals);
                    break;
            }
        }

        foreach (var number in toBeExcluded.Reverse())
        {
            gems.RemoveAt(number);
        }
        gems.RemoveAt(gems.Count - 1);
        gems.RemoveAt(0);

        Console.WriteLine(string.Join(" ", gems));
    }

    private static void ReadCommands(List<string> commands)
    {
        string input;
        while ((input = Console.ReadLine()) != "Forge")
        {
            var args = input.Split(';').ToArray();
            if (args[0] == "Reverse")
            {
                var comToRemove = input.Replace("Reverse", "Exclude");
                commands.Remove(comToRemove);
            }
            else
            {
                commands.Add(input);
            }
        }
    }

    private static void SumLeftRight(List<int> gems, SortedSet<int> toBeExcluded, int border, Func<int, int, bool> @equals)
    {
        for (int i = 1; i < gems.Count - 1; i++)
        {
            if (equals(gems[i] + gems[i - 1] + gems[i + 1], border))
            {
                toBeExcluded.Add(i);
            }
        }
    }

    private static void SumRight(List<int> gems, SortedSet<int> toBeExcluded, int border, Func<int, int, bool> @equals)
    {
        for (int i = 1; i < gems.Count - 1; i++)
        {
            if (equals(gems[i] + gems[i + 1], border))
            {
                toBeExcluded.Add(i);
            }
        }
    }

    private static void SumLeft(List<int> gems, SortedSet<int> toBeExcluded, int border, Func<int, int, bool> equals)
    {
        for (int i = 1; i < gems.Count - 1; i++)
        {
            if (equals(gems[i] + gems[i - 1], border))
            {
                toBeExcluded.Add(i);
            }
        }
    }
}