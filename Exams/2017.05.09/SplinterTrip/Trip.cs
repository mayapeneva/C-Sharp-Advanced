namespace SplinterTrip
{
    using System;

    public class Trip
    {
        public static void Main()
        {
            var distanceInMiles = double.Parse(Console.ReadLine());
            var fuelTankInLiters = double.Parse(Console.ReadLine());
            var milesInWinds = double.Parse(Console.ReadLine());

            var fuelNeeded = (distanceInMiles * 25 + milesInWinds * (25 * 0.5)) * 1.05;
            Console.WriteLine($"Fuel needed: {fuelNeeded:F2}L");

            var fuelDifference = Math.Abs(fuelNeeded - fuelTankInLiters);
            if (fuelNeeded <= fuelTankInLiters)
            {
                Console.WriteLine($"Enough with {fuelDifference:F2}L to spare!");
            }
            else
            {
                Console.WriteLine($"We need {fuelDifference:F2}L more fuel.");
            }
        }
    }
}
