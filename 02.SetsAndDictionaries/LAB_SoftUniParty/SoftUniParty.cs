using System;
using System.Collections.Generic;

namespace LAB_SoftUniParty
{
    public class SoftUniParty
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var guestList = new SortedSet<string>();
            while (input != "PARTY")
            {
                guestList.Add(input);

                input = Console.ReadLine();
            }

            while (input != "END")
            {
                guestList.RemoveWhere(g => g.Contains(input));

                input = Console.ReadLine();
            }

            Console.WriteLine(guestList.Count);
            foreach (var guest in guestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
