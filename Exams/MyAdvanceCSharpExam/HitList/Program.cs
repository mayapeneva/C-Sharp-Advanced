using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var targetInfoIndex = int.Parse(Console.ReadLine());

        var people = new Dictionary<string, Person>();
        string input;
        while ((input = Console.ReadLine()) != "end transmissions")
        {
            FileAllData(people, input);
        }

        var finalCommand = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        PrintResult(targetInfoIndex, people, finalCommand);
    }

    private static void PrintResult(int targetInfoIndex, Dictionary<string, Person> people, string[] finalCommand)
    {
        var theName = finalCommand[1];
        Console.WriteLine($"Info on {theName}:");
        foreach (var info in people[theName].Infos.OrderBy(i => i.Key))
        {
            Console.WriteLine($"---{info.Key}: {info.Value}");
        }

        var personInfo = people[theName].GetPersonsInfoIndex();
        Console.WriteLine($"Info index: {personInfo}");
        if (personInfo >= targetInfoIndex)
        {
            Console.WriteLine("Proceed");
        }
        else
        {
            Console.WriteLine($"Need {targetInfoIndex - personInfo} more info.");
        }
    }

    private static void FileAllData(Dictionary<string, Person> people, string input)
    {
        var tokens = input.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
        var name = tokens[0];
        if (!people.ContainsKey(name))
        {
            people[name] = new Person();
        }

        var details = tokens[1].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var detail in details)
        {
            var args = detail.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            var theKey = args[0];
            var theValue = args[1];
            if (!people[name].Infos.ContainsKey(args[0]))
            {
                people[name].Infos[theKey] = string.Empty;
            }

            people[name].Infos[theKey] = theValue;
        }
    }
}