using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        var line = Console.ReadLine();

        var indexes = new Queue<int>();
        var regex = new Regex(@"\[[^\s\[]+<(\d+)REGEH(\d+)>[^\s\[]+\]");
        if (regex.IsMatch(line))
        {
            var matches = regex.Matches(line);
            foreach (Match match in matches)
            {
                indexes.Enqueue(int.Parse(match.Groups[1].Value));
                indexes.Enqueue(int.Parse(match.Groups[2].Value));
            }
        }

        var result = new StringBuilder();
        var index = 0;
        while (indexes.Count > 0)
        {
            index += indexes.Dequeue();
            if (index >= line.Length)
            {
                index = index - line.Length + 1;
            }

            result.Append(line[index]);
        }

        Console.WriteLine(string.Join("", result));
    }
}