using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var inputs = new Queue<string>();
        for (int i = 0; i < n; i++)
        {
            inputs.Enqueue(Console.ReadLine());
        }

        var namePatttern = Console.ReadLine();
        var messagePattern = Console.ReadLine();

        var names = new List<string>();
        var messages = new List<string>();

        var nameRegex = new Regex(Regex.Escape(namePatttern) + @"([a-zA-Z]+)[^a-zA-Z]*");
        var messageRegex = new Regex(Regex.Escape(messagePattern) + @"([a-zA-Z0-9]+)[^a-zA-Z0-9]*");
        foreach (var input in inputs)
        {
            var nameMatches = nameRegex.Matches(input);
            foreach (Match nameM in nameMatches)
            {
                var nameMatch = nameM.Groups[1].Value;
                if (nameMatch.Length == namePatttern.Length)
                {
                    names.Add(nameMatch);
                }
            }

            var messageMatches = messageRegex.Matches(input);
            foreach (Match messageM in messageMatches)
            {
                var messageMatch = messageM.Groups[1].Value;
                if (messageMatch.Length == messagePattern.Length)
                {
                    messages.Add(messageMatch);
                }
            }
        }

        var result = new List<string>();
        var numbers = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            .ToArray();
        for (int j = 0; j < names.Count; j++)
        {
            var index = numbers[j] - 1;
            var nm = names[j];
            var msg = string.Empty;
            if (index >= 0 && index < messages.Count)
            {
                msg = messages[index];
            }
            else
            {
                j++;
                while (j < numbers.Length)
                {
                    if (j < messages.Count)
                    {
                        msg = messages[j];
                        break;
                    }

                    j++;
                }
            }

            if (msg != string.Empty)
            {
                result.Add($"{nm} - {msg}");
            }
        }

        foreach (var line in result)
        {
            Console.WriteLine(line);
        }
    }
}