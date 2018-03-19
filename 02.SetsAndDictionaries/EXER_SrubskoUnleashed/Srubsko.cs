using System;
using System.Collections.Generic;
using System.Linq;

public class Unleashed
{
    public static void Main()
    {
        var firstInput = Console.ReadLine();

        var venueList = new Dictionary<string, Dictionary<string, int>>();
        while (firstInput != "End" && firstInput.Contains('@'))
        {
            var fullInput = firstInput.Split('@');
            var singer = fullInput[0].Trim();
            var input = fullInput[1].Split(' ').ToList();

            var ticketPrice = 0;
            var ticketNumber = 0;
            if (int.TryParse(input[input.Count - 2], out ticketPrice) &&
                int.TryParse(input[input.Count - 1], out ticketNumber))
            {
                input.RemoveRange(input.Count - 2, 2);
                var venue = string.Join(" ", input);

                if (!venueList.ContainsKey(venue))
                {
                    venueList[venue] = new Dictionary<string, int>();
                }

                if (!venueList[venue].ContainsKey(singer))
                {
                    venueList[venue][singer] = 0;
                }

                venueList[venue][singer] += ticketNumber * ticketPrice;
            }

            firstInput = Console.ReadLine();
        }

        foreach (var venue in venueList)
        {
            Console.WriteLine(venue.Key);
            foreach (var singer in venue.Value.OrderByDescending(key => key.Value))
            {
                Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
            }
        }
    }
}