using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LAB_ExtractQuotations
{
    public class Quotations
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var regex = new Regex("(?:'([^']+)?')|(?:\"([^\"]+)?\")");
            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                if (match.Groups[1].Value.Any())
                {
                    Console.WriteLine(match.Groups[1].Value);
                }

                if (match.Groups[2].Value.Any())
                {
                    Console.WriteLine(match.Groups[2].Value);
                }
            }
        }
    }
}
