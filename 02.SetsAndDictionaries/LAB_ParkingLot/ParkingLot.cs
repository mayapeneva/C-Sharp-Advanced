using System;
using System.Collections.Generic;

namespace LAB_ParkingLot
{
    public class ParkingLot
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);

            var cars = new SortedSet<string>();
            while (input[0] != "END")
            {
                var plate = input[1];
                switch (input[0])
                {
                    case "IN": cars.Add(plate);
                        break;
                    case "OUT":
                        if (cars.Contains(plate))
                        {
                            cars.Remove(plate);
                        }
                        break;
                }

                input = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
