using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EXER_QueryMess
{
    public class QueryMess
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"[^&\?=]+=[%\w\+\/:\.]+");
            while (input != "END")
            {
                var matches = regex.Matches(input);
                var result = new Dictionary<string, List<string>>();
                foreach (Match match in matches)
                {
                    var exactMatch = Regex.Split(match.Value, "=");
                    var key = Regex.Replace(exactMatch[0], @"\+", " ");
                    key = Regex.Replace(key, "%20", " ");
                    var value = Regex.Replace(exactMatch[1], @"\+", " ");
                    value = Regex.Replace(value, "%20", " ");
                    key = Regex.Replace(key.Trim(), @"\s+", " ");
                    value = Regex.Replace(value.Trim(), @"\s+", " ");
                    if (!result.ContainsKey(key))
                    {
                        result[key] = new List<string>();
                    }

                    result[key].Add(value);
                }

                foreach (var kvp in result)
                {
                    Console.Write($"{kvp.Key}=[{string.Join(", ", kvp.Value)}]");
                }
                Console.WriteLine();

                input = Console.ReadLine();
            }
        }
    }
}
