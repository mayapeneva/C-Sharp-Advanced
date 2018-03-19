using System;
using System.Text.RegularExpressions;

namespace EXER_ExtractEmail
{
    public class ExtractEmail
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"\s[^\.-_][\w\.-]+[^\.-_]@([\w-]+?\.){1,}[\w-]{2,}");
            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
