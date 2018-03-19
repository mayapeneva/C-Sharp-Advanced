using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_HandsOfCards
{
    public class Cards
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries);

            var result = new Dictionary<string, HashSet<string>>();
            while (input[0] != "JOKER")
            {
                var name = input[0];
                var cards = input[1].Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                if (!result.ContainsKey(name))
                {
                    result[name] = new HashSet<string>();
                }

                foreach (var card in cards)
                {
                    result[name].Add(card.Trim());
                }

                input = Console.ReadLine().Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var person in result)
            {
                var cardsValue = 0;
                foreach (var tocken in person.Value)
                {
                    var card = tocken.ToArray();
                    var t = card[card.Length - 1];
                    var type = t == 'S' ? 4 : t == 'H' ? 3 : t == 'D' ? 2 : 1;

                    var power = 0;
                    if (card.Length == 2)
                    {
                        var p = card[0];
                        power = p == 'J' ? 11 : p == 'Q' ? 12 : p == 'K' ? 13 : p == 'A'? 14 : int.Parse(p.ToString());
                    }
                    else
                    {
                        power = 10;
                    }

                    cardsValue += power * type;
                }

                Console.WriteLine($"{person.Key}: {cardsValue}");
            }
        }
    }
}
