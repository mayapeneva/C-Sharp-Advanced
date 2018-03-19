using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        var intList = new List<string>();
        var doubleList = new List<string>();

        string input;
        while ((input = Console.ReadLine()) != "//END_OF_CODE")
        {
            var intRegex = new Regex(@"int\s([a-z][a-zA-Z]*)");
            var intMatches = intRegex.Matches(input);
            if (intMatches.Count > 0)
            {
                foreach (Match intMatch in intMatches)
                {
                    intList.Add(intMatch.Groups[1].Value);
                }
            }

            var doubleRegex = new Regex(@"double\s([a-z][a-zA-Z]*)");
            var doubleMatches = doubleRegex.Matches(input);
            if (doubleMatches.Count > 0)
            {
                foreach (Match doubleMatch in doubleMatches)
                {
                    doubleList.Add(doubleMatch.Groups[1].Value);
                }
            }
        }

        if (doubleList.Count > 0)
        {
            doubleList.Sort();
            Console.WriteLine($"Doubles: {string.Join(", ", doubleList)}");
        }
        else
        {
            Console.WriteLine("Doubles: None");
        }

        if (intList.Count > 0)
        {
            intList.Sort();
            Console.WriteLine($"Ints: {string.Join(", ", intList)}");
        }
        else
        {
            Console.WriteLine("Ints: None");
        }
    }
}