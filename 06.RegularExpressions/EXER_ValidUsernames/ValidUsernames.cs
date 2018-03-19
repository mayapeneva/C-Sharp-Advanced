using System;
using System.Text.RegularExpressions;

namespace EXER_ValidUsernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var line = Regex.Split(input, @"[\s\\/\(\)$]");

            var regex = new Regex(@"\b[a-zA-Z][\w+]{2,24}\b");
            var previousMatch = regex.Match(line[0]);

            var sum = 0;
            var firstMatch = string.Empty;
            var secondMatch = string.Empty;
            for (int i = 1; i < line.Length; i++)
            {
                if (regex.IsMatch(line[i]))
                {
                    var match = regex.Match(line[i]);
                    if (match.Length + previousMatch.Length > sum)
                    {
                        sum = match.Length + previousMatch.Length;
                        firstMatch = previousMatch.ToString();
                        secondMatch = match.ToString();
                    }
                    previousMatch = regex.Match(line[i]);
                }

            }

            Console.WriteLine(firstMatch);
            Console.WriteLine(secondMatch);
        }
    }
}
