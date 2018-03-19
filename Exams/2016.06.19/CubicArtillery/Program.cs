using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int maxBunkerCapacity;
    private static Queue<Bunker> bunkers = new Queue<Bunker>();

    public static void Main()
    {
        maxBunkerCapacity = int.Parse(Console.ReadLine());

        string input;
        while ((input = Console.ReadLine()) != "Bunker Revision")
        {
            var args = input.Split().ToArray();

            foreach (var item in args)
            {
                if (Char.IsLetter(item[0]))

                {
                    bunkers.Enqueue(new Bunker(item[0]));
                }
                else
                {
                    var weapon = int.Parse(item);
                    var bunker = bunkers.Peek();
                    var weaponFitted = false;
                    while (bunkers.Count > 1)
                    {
                        if (bunker.Capacity + weapon <= maxBunkerCapacity)
                        {
                            bunker.Weapons.Enqueue(weapon);
                            bunker.Capacity += weapon;
                            weaponFitted = true;
                            break;
                        }

                        Console.WriteLine(bunker.Weapons.Count == 0
                            ? $"{bunker.Name} -> Empty"
                            : $"{bunker.Name} -> {string.Join(", ", bunker.Weapons)}");

                        bunkers.Dequeue();
                        bunker = bunkers.Peek();
                    }

                    if (!weaponFitted)
                    {
                        if (weapon <= maxBunkerCapacity)
                        {
                            while (bunker.Capacity + weapon > maxBunkerCapacity)
                            {
                                bunker.Capacity -= bunker.Weapons.Dequeue();
                            }

                            bunker.Weapons.Enqueue(weapon);
                            bunker.Capacity += weapon;
                        }
                    }
                }
            }
        }
    }
}