using System;
using System.Text.RegularExpressions;

namespace EXER_SentenceExtractor
{
    public class SentenceExtractor
    {
        public static void Main()
        {
            var pattern = Console.ReadLine().Insert(0, " ");
            var text = Console.ReadLine();

            var regex = new Regex(@"[^\.!?]+?[\.!?]");
            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                if (match.ToString().Contains($"{pattern}"))
                {
                    Console.WriteLine(match.ToString().Trim());
                }
            }
        }
    }
}
