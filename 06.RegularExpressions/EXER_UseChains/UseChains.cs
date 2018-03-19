using System;
using System.Text;
using System.Text.RegularExpressions;

namespace EXER_UseChains
{
    public class UseChains
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"<p>(.+?)<\/p>");
            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var newTag = new StringBuilder();
                for (int i = 0; i < match.Groups[1].Length; i++)
                {
                    var symbol = match.Groups[1].Value[i];
                    if (symbol > 96 & symbol < 110)
                    {
                        newTag.Append((char)(symbol + 13));
                    }
                    else if (symbol > 109 & symbol < 123)
                    {
                        newTag.Append((char)(symbol - 13));
                    }
                    else if (symbol > 47 & symbol < 58)
                    {
                        newTag.Append(symbol);
                    }
                    else
                    {
                        newTag.Append(" ");
                    }
                }

                var result = Regex.Replace(newTag.ToString(), @" +", " ");

                Console.Write(result);
            }

            Console.WriteLine();
        }
    }
}
