using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        long bagCapacity = long.Parse(Console.ReadLine());

        var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        var sequence = new Queue<string>(input);

        var bagQuantites = new Dictionary<string, int>();
        var bagItems = new Dictionary<string, Dictionary<string, int>>();
        bagQuantites["Gold"] = 0;
        bagItems["Gold"] = new Dictionary<string, int>();
        bagQuantites["Gem"] = 0;
        bagItems["Gem"] = new Dictionary<string, int>();
        bagQuantites["Cash"] = 0;
        bagItems["Cash"] = new Dictionary<string, int>();

        while (sequence.Count > 0)
        {
            var item = sequence.Dequeue();
            var quantity = int.Parse(sequence.Dequeue());
            if (bagQuantites.Sum(i => i.Value) + quantity > bagCapacity)
            {
                break;
            }

            if (item.Equals("gold", StringComparison.InvariantCultureIgnoreCase))
            {
                bagQuantites["Gold"] += quantity;
                if (!bagItems["Gold"].ContainsKey("Gold"))
                {
                    bagItems["Gold"]["Gold"] = 0;
                }

                bagItems["Gold"]["Gold"] += quantity;
            }
            else if (item.Length == 3)
            {
                if (bagQuantites["Cash"] + quantity <= bagQuantites["Gem"])
                {
                    bagQuantites["Cash"] += quantity;
                    bagItems["Cash"].Add(item, quantity);
                }
            }
            else if (item.ToLower().Contains("gem"))
            {
                if (bagQuantites["Gem"] + quantity <= bagQuantites["Gold"])
                {
                    bagQuantites["Gem"] += quantity;
                    bagItems["Gem"].Add(item, quantity);
                }
            }
        }

        foreach (var kvp in bagQuantites.OrderByDescending(i => i.Value))
        {
            if (kvp.Value > 0)
            {
                Console.WriteLine($"<{kvp.Key}> ${kvp.Value}");

                foreach (var item in bagItems[kvp.Key].OrderByDescending(i => i.Key).ThenBy(i => i.Value))
                {
                    var itemName = kvp.Key.Equals("gold", StringComparison.InvariantCultureIgnoreCase) ? "Gold" : item.Key;
                    Console.WriteLine($"##{itemName} - {item.Value}");
                }
            }
        }
    }
}