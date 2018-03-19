using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var invited = Console.ReadLine().Split().ToList();

        var commands = new List<string[]>();
        string input;
        while ((input = Console.ReadLine()) != "Print")
        {
            var args = input.Split(';').ToArray();
            if (args[0] == "Remove filter")
            {
                args[0].Replace("Remove", "Add");
                commands.RemoveAll(a => a.Equals(args));
            }
            commands.Add(args);
        }

        foreach (var command in commands)
        {
            ApplyFilter(invited, command);
        }

        Console.WriteLine(string.Join(" ", invited));
    }

    private static void ApplyFilter(List<string> invited, string[] command)
    {
        Func<string, string, bool> startsWith = (n, s) => n.StartsWith(s);
        Func<string, string, bool> endsWith = (n, s) => n.EndsWith(s);
        Func<string, string, bool> length = (n, l) => n.Length == int.Parse(l);
        Func<string, string, bool> contains = (n, s) => n.Contains(s);

        var condition = command[1];
        var param = command[2];
        switch (condition)
        {
            case "Starts with":
                invited.RemoveAll(name => startsWith(name, param));
                break;

            case "Ends with":
                invited.RemoveAll(name => endsWith(name, param));
                break;

            case "Length":
                invited.RemoveAll(name => length(name, param));
                break;

            case "Contains":
                invited.RemoveAll(name => contains(name, param));
                break;
        }
    }
}