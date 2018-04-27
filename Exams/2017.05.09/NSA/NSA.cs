using System.Linq;

namespace NSA
{
    using System;
    using System.Collections.Generic;

    public class NSA
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);

            var result = new Dictionary<string, Dictionary<string, int>>();
            while (input[0] != "quit")
            {
                var country = input[0];
                var spy = input[1];
                var daysInService = int.Parse(input[2]);
                if (!result.ContainsKey(country))
                {
                    result[country] = new Dictionary<string, int>();
                }

                result[country][spy] = daysInService;

                input = Console.ReadLine().Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var country in result.OrderByDescending(c => c.Value.Count))
            {
                Console.WriteLine($"Country: {country.Key}");
                foreach (var spy in country.Value.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"**{spy.Key} : {spy.Value}");
                }
            }
        }
    }
}
