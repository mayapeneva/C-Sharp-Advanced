using System;
using System.Text.RegularExpressions;

namespace EXER_SemanticHTML
{
    public class HTML
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                var openMatch = Regex.Match(input, @"<(div)(.+?)(?:id|class)\s*=\s*""([a-z]+?)""(.*?)>");
                var closeMatch = Regex.Match(input, @"<\/(div)>(\s*<!-+\s*(?<value>[a-z]+?)\s*-+>)");
                if (openMatch.Success)
                {
                    input = Regex.Replace(input, @"<(div)(.+?)(?:id|class)\s*=\s*""([a-z]+?)""(.*?)>", @"$3 $2 $4").Trim();
                    input = "<" + Regex.Replace(input, @"\s+", " ") + ">";
                }
                else if (closeMatch.Success)
                {
                    input = "</" + closeMatch.Groups["value"].Value + ">";
                }

                Console.WriteLine(input);

                input = Console.ReadLine();
            }
        }
    }
}