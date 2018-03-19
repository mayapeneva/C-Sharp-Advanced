using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Func<string, string, bool> startsWith = (n, s) => n.StartsWith(s);
        Func<string, string, bool> endsWith = (n, s) => n.EndsWith(s);
        Func<string, string, bool> longAs = (n, l) => n.Length == int.Parse(l);

        var invited = Console.ReadLine().Split().ToList();

        string command;
        while ((command = Console.ReadLine()) != "Party!")
        {
            var args = command.Split();
            var action = args[0];
            var whereToAct = args[1];
            var param = args[2];
            switch (whereToAct)
            {
                case "StartsWith":
                    if (action == "Remove")
                    {
                        RemoveMatchingNames(invited, startsWith, param);
                        break;
                    }

                    DoubleMatchingNames(invited, startsWith, param);
                    break;

                case "EndsWith":
                    if (action == "Remove")
                    {
                        RemoveMatchingNames(invited, endsWith, param);
                        break;
                    }

                    DoubleMatchingNames(invited, endsWith, param);
                    break;

                case "Length":
                    if (action == "Remove")
                    {
                        RemoveMatchingNames(invited, longAs, param);
                        break;
                    }

                    DoubleMatchingNames(invited, longAs, param);
                    break;
            }
        }

        PrintGuestList(invited);
    }

    private static void PrintGuestList(List<string> invited)
    {
        Console.WriteLine(invited.Count != 0
            ? $"{string.Join(", ", invited)} are going to the party!"
            : "Nobody is going to the party!");
    }

    private static void RemoveMatchingNames(List<string> invited, Func<string, string, bool> function, string param)
    {
        invited.RemoveAll(name => function(name, param));
    }

    private static void DoubleMatchingNames(List<string> invited, Func<string, string, bool> function, string param)
    {
        for (int i = 0; i < invited.Count; i++)
        {
            var name = invited[i];
            if (function(name, param))
            {
                invited.Insert(i + 1, name);
                i++;
            }
        }
    }
}