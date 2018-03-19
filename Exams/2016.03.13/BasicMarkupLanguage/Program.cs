using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        var number = 1;

        string line;
        while ((line = Console.ReadLine()) != "<stop/>")
        {
            var regex = new Regex(@"<\s*([a-zA-Z]+)\s[^<>]+""([\sa-zA-Z0-9:#]+)""\s*\/>");
            var match = regex.Match(line);
            var command = match.Groups[1].Value;
            var content = match.Groups[2].Value;
            if (content.Length > 0)
            {
                switch (command)
                {
                    case "inverse":
                        Console.Write(Char.IsLower(content[0])
                            ? $"{number}. {content[0].ToString().ToUpper()}"
                            : $"{number}. {content[0].ToString().ToLower()}");

                        for (int i = 1; i < content.Length; i++)
                        {
                            Console.Write(Char.IsLower(content[i])
                                ? content[i].ToString().ToUpper()
                                : content[i].ToString().ToLower());
                        }
                        Console.WriteLine();
                        break;

                    case "reverse":
                        Console.WriteLine($"{number}. {string.Join("", content.Reverse().ToArray())}");
                        break;

                    case "repeat":
                        var repeatRegex = new Regex(@"<\s*[a-zA-Z]+\s+[^<>]+?""(\d+)""");
                        var repeatMatch = repeatRegex.Match(line);
                        var count = int.Parse(repeatMatch.Groups[1].Value);

                        if (count > 0)
                        {
                            Console.WriteLine($"{number}. {content}");
                            for (int j = 1; j < count; j++)
                            {
                                number++;
                                Console.WriteLine($"{number}. {content}");
                            }
                        }
                        else
                        {
                            number--;
                        }
                        break;
                }

                number++;
            }
        }
    }
}