using System;

namespace EXER_ExtractHyperlinks
{
    public class Hyperlinks
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                var hyperlink = string.Empty;
                if (input.Contains("<a") && input.Contains("</a>")
                    && (input.Contains("href=") || input.Contains("href =")))
                {
                    input = input.Remove(0, input.IndexOf("<a"));
                    if (input.IndexOf("<a") < input.IndexOf(">")
                        && input.IndexOf(">") < input.IndexOf("</a>"))
                    {
                        var startIndex = input.IndexOf("href=") > input.IndexOf("href =") ? input.IndexOf("href=") + 5 : input.IndexOf("href =") + 6;
                        var tempInput = input.Remove(0, startIndex);
                        if (tempInput[0] == ' ')
                        {
                            tempInput = tempInput.Trim();
                        }

                        var endIndex = 0;
                        if (tempInput.IndexOf(' ') > -1 && tempInput.IndexOf(' ') < tempInput.IndexOf('>'))
                        {
                            endIndex = tempInput.IndexOf(' ');
                        }
                        else
                        {
                            endIndex = tempInput.IndexOf('>');
                        }

                        hyperlink = tempInput.Substring(0, endIndex);
                    }
                }

                Console.WriteLine(hyperlink.Trim(' ', '\'', '"'));

                input = Console.ReadLine();
            }
        }
    }
}
