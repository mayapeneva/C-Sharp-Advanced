using System;
using System.Text.RegularExpressions;

namespace LAB_MatchCount
{
    public class MatchCount
    {
        public static void Main()
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();

            var regex = new Regex(word);
            var matchesCount = regex.Matches(text).Count;

            Console.WriteLine(matchesCount);
        }
    }
}
