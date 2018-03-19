using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EXER_ExtractHyperlinks
{
    public class Hyperlinks
    {
        public static void Main()
        {
            var line = Console.ReadLine();

            var text = new StringBuilder();
            while (line != "END")
            {
                text.Append(line).Append(" ");

                line = Console.ReadLine();
            }

            var regex = new Regex(@"<a\s+.*?href\s*=(.+?)>.+?<\s*\/\s*a\s*>");
            var matches = regex.Matches(text.ToString());
            foreach (Match match in matches)
            {
                var temp = match.Groups[1].ToString().Trim();
                var result = string.Empty;
                if (temp[0] == '"')
                {
                    result = temp.Split(new[] { '"' }, StringSplitOptions.RemoveEmptyEntries).First();
                }
                else if (temp[0] == '\'')
                {
                    result = temp.Split(new[] { '\'' }, StringSplitOptions.RemoveEmptyEntries).First();
                }
                else
                {
                    result = Regex.Split(temp, @"\s+").First();
                }

                Console.WriteLine(result);
            }
        }
    }
}
