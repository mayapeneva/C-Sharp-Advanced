using System;
using System.Text.RegularExpressions;

namespace LAB_VowelCount
{
    public class VowelCount
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"[aeiouyAEIOUY]");
            var matchesCount = regex.Matches(text).Count;

            Console.WriteLine($"Vowels: {matchesCount}");
        }
    }
}
