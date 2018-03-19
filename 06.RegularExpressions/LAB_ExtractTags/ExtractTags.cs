using System;
using System.Text.RegularExpressions;

namespace LAB_ExtractTags
{
    public class ExtractTags
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"<[^<>]+>");
            while (input != "END")
            {
                var matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match);
                }

                input = Console.ReadLine();
            }
        }
    }
}
