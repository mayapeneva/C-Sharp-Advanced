using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        var regex = new Regex(@"[!|#][^!#]*?\b([A-Za-z]{4})\b[^!#]*(?<!\d)(\d{3})-(\d{6}|\d{4})(?!\d)[^!#]*?(?!\1)(#|!)");

        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();
            GetAndPrintMatches(regex, input);
        }
    }

    private static void GetAndPrintMatches(Regex regex, string input)
    {
        var matches = regex.Matches(input);
        var correctMatch = matches[matches.Count / 2];
        Console.WriteLine($"Go to str. {correctMatch.Groups[1].Value} {correctMatch.Groups[2].Value}. Secret pass: {correctMatch.Groups[3].Value}.");
    }
}