using System;
using System.Text.RegularExpressions;

namespace LAB_ExtractIntegerNumbers
{
    public class IntNumbers
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"\d+");
            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
