using System;
using System.Text.RegularExpressions;

namespace EXER_MatchFullName
{
    public class FullName
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"^[A-Z][a-z]+ [A-Z][a-z]+$");
            while (input != "end")
            {
                var matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    if (regex.IsMatch(input))
                    {
                        Console.WriteLine(match);
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
