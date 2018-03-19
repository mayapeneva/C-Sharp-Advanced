using System;
using System.Text.RegularExpressions;

namespace LAB_NonDigitCount
{
    public class NonDigitCount
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"\D");
            var matchesCount = regex.Matches(text).Count;

            Console.WriteLine($"Non-digits: {matchesCount}");
        }
    }
}
