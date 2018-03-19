using System;
using System.Collections.Generic;

namespace EXER_LogsAggregator
{
    public class Logs
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var users = new SortedDictionary<string, int>();
            var ips = new SortedDictionary<string, SortedSet<string>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var ip = input[0];
                var userName = input[1];
                var duration = int.Parse(input[2]);

                if (!users.ContainsKey(userName))
                {
                    users[userName] = 0;
                    ips[userName] = new SortedSet<string>();
                }

                users[userName] += duration;
                ips[userName].Add(ip);
            }

            foreach (var user in users)
            {
                var name = user.Key;
                Console.Write($"{name}: {user.Value} ");
                Console.Write("[{0}]", string.Join(", ", ips[name]));
                Console.WriteLine();
            }
        }
    }
}
