using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_UserLogs
{
    public class UserLogs
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var result = new SortedDictionary<string, Dictionary<string, int>>();
            while (input[0] != "end")
            {
                var ip = input[0].Split('=')[1];
                var user = input[2].Split('=')[1];
                if (!result.ContainsKey(user))
                {
                    result[user] = new Dictionary<string, int>();
                }

                if (!result[user].ContainsKey(ip))
                {
                    result[user][ip] = 0;
                }
                result[user][ip]++;

                input = Console.ReadLine().Split();
            }

            foreach (var person in result)
            {
                Console.WriteLine($"{person.Key}:");
                Console.WriteLine("{0}.", string.Join(", ", person.Value.Select(a => $"{a.Key} => {a.Value}")));
            }
        }
    }
}