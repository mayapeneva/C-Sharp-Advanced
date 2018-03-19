using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static Dictionary<string, Region> regions = new Dictionary<string, Region>();

    public static void Main()
    {
        string input;
        while ((input = Console.ReadLine()) != "Count em all")
        {
            var args = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            var region = args[0];
            var meteorType = args[1];
            var meteorCount = int.Parse(args[2]);

            if (!regions.ContainsKey(region))
            {
                regions[region] = new Region(region);
            }

            regions[region].Meteors[meteorType] += meteorCount;

            if (meteorType == "Red")
            {
                regions[region].CheckRedMeteors();
            }
            else if (meteorType == "Green")
            {
                regions[region].CheckGreenMeteors();
            }
        }

        foreach (var region in regions.Values.OrderByDescending(r => r.Meteors["Black"]).ThenBy(r => r.Name.Length).ThenBy(r => r.Name))
        {
            Console.WriteLine(region.Name);

            foreach (var meteor in region.Meteors.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
            {
                Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
            }
        }
    }
}