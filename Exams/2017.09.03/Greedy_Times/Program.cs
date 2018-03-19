using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        long bagTotalCapacity = long.Parse(Console.ReadLine());

        var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        var sequence = new Queue<string>(input);

        var bag = new Bag();
        while (sequence.Count > 0)
        {
            var item = sequence.Dequeue();
            long quantity = long.Parse(sequence.Dequeue());
            if (bag.GetCapacity() + quantity > bagTotalCapacity)
            {
                break;
            }

            if (item.Equals("gold", StringComparison.InvariantCultureIgnoreCase))
            {
                if (!bag.Gold.ContainsKey("Gold"))
                {
                    bag.Gold["Gold"] = 0;
                }

                bag.Gold["Gold"] += quantity;
            }
            else if (item.Length == 3)
            {
                if (bag.GetTotalCash() + quantity <= bag.GetTotalGems())
                {
                    if (!bag.Cash.ContainsKey(item))
                    {
                        bag.Cash[item] = 0;
                    }

                    bag.Cash[item] += quantity;
                }
            }
            else if (item.Length >= 4 && item.EndsWith("gem", StringComparison.InvariantCultureIgnoreCase))
            {
                if (bag.GetTotalGems() + quantity <= bag.GetTotalGold())
                {
                    if (!bag.Gem.ContainsKey(item))
                    {
                        bag.Gem[item] = 0;
                    }

                    bag.Gem[item] += quantity;
                }
            }
        }

        PrintOut(bag.Gold, "Gold");
        PrintOut(bag.Gem, "Gem");
        PrintOut(bag.Cash, "Cash");
    }

    private static void PrintOut(Dictionary<string, long> tresures, string name)
    {
        long totalValue = tresures.Sum(t => t.Value);
        if (totalValue > 0)
        {
            Console.WriteLine($"<{name}> ${tresures.Sum(t => t.Value)}");

            if (name.Equals("Gold"))
            {
                Console.WriteLine($"##Gold - {totalValue}");
            }
            else
            {
                foreach (var item in tresures.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}