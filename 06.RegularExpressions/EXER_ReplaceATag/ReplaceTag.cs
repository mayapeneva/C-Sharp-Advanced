using System;
using System.Text;
using System.Text.RegularExpressions;

namespace EXER_ReplaceATag
{
    public class ReplaceTag
    {
        public static void Main()
        {
            var line = Console.ReadLine();

            var input = new StringBuilder();
            while (line != "end")
            {
                input.AppendLine(line);

                line = Console.ReadLine();
            }

            var pattern = @"<a( href=.+?)>(.+)<\/a>";
            var result = Regex.Replace(input.ToString(), pattern, @"[URL$1]$2[/URL]");

            Console.WriteLine(result);
        }
    }
}