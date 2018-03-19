using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_PopulationCounter
{
    public class Population
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split('|');

            var countries = new Dictionary<string, long>();
            var cities = new Dictionary<string, Dictionary<string, int>>();
            while (input[0] != "report")
            {
                var city = input[0];
                var country = input[1];
                var cityPopulation = int.Parse(input[2]);

                if (!countries.ContainsKey(country))
                {
                    countries[country] = 0;
                    cities[country] = new Dictionary<string, int>();
                }

                countries[country] += cityPopulation;
                cities[country][city] = cityPopulation;

                input = Console.ReadLine().Split('|');
            }

            foreach (var token in countries.OrderByDescending(t => t.Value))
            {
                var countryName = token.Key;
                Console.WriteLine($"{countryName} (total population: {token.Value})");

                foreach (var city in cities[countryName].OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
