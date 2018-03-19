using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var methods = new Dictionary<string, List<string>>();
        var main = string.Empty;
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"([A-Z][a-zA-Z]+)\(");
            if (input.Contains("static"))
            {
                var mainMatch = regex.Match(input);
                main = mainMatch.Groups[1].Value;
                methods[main] = new List<string>();
            }
            else
            {
                var matches = regex.Matches(input);
                foreach (Match match in matches)
                {
                    var method = match.Groups[1].Value;
                    methods[main].Add(method);
                }
            }
        }

        foreach (var kvp in methods.OrderByDescending(m => m.Value.Count).ThenBy(m => m.Key))
        {
            Console.Write($"{kvp.Key} -> {kvp.Value.Count} -> ");
            var innerMethods = kvp.Value.OrderBy(m => m);
            Console.WriteLine(string.Join(", ", innerMethods));
        }
    }
}