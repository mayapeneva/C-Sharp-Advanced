using System;
using System.Collections.Generic;
using System.Linq;

public class LegFarming
{
    public static void Main()
    {
        var keyMaterials = new Dictionary<string, int>();
        keyMaterials.Add("shards", 0);
        keyMaterials.Add("fragments", 0);
        keyMaterials.Add("motes", 0);

        var junkMaterials = new SortedDictionary<string, int>();
        var legendary = string.Empty;

        while (legendary == string.Empty)
        {
            var input = Console.ReadLine().ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < input.Length; i += 2)
            {
                var material = input[i];
                var quantity = int.Parse(input[i - 1]);
                if (material == "shards" || material == "fragments" || material == "motes")
                {
                    keyMaterials[material] += quantity;

                    if (keyMaterials[material] >= 250)
                    {
                        switch (material)
                        {
                            case "shards": legendary = "Shadowmourne"; break;
                            case "fragments": legendary = "Valanyr"; break;
                            case "motes": legendary = "Dragonwrath"; break;
                        }
                        keyMaterials[material] -= 250;
                        break;
                    }
                }
                else
                {
                    if (!junkMaterials.ContainsKey(material))
                    {
                        junkMaterials[material] = 0;
                    }

                    junkMaterials[material] += quantity;
                }
            }
        }

        Console.WriteLine($"{legendary} obtained!");

        foreach (var keyMaterial in keyMaterials.OrderByDescending(key => key.Value).ThenBy(key => key.Key))
        {
            Console.WriteLine($"{keyMaterial.Key}: {keyMaterial.Value}");
        }

        foreach (var junkMaterial in junkMaterials)
        {
            Console.WriteLine($"{junkMaterial.Key}: {junkMaterial.Value}");
        }
    }
}