using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB_MaxDistricts
{
    public class MapDistricts
    {
        public static void Main()
        {
            // to try with class
            var cities = new Dictionary<string, List<long>>();
            var districts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var district in districts)
            {
                var tokens = district.Split(':');
                var cityName = tokens[0].Trim();
                var districtPopulation = long.Parse(tokens[1].Trim());
                if (!cities.ContainsKey(cityName))
                {
                    cities[cityName] = new List<long>();
                }

                cities[cityName].Add(districtPopulation);
            }

            var minPopulation = long.Parse(Console.ReadLine().Trim());

            foreach (var kvp in cities.Where(c => c.Value.Sum() >= minPopulation).OrderByDescending(c => c.Value.Sum()))
            {
                Console.WriteLine($"{kvp.Key}: {string.Join(" ", kvp.Value.OrderByDescending(p => p))}");
            }
        }
    }
}