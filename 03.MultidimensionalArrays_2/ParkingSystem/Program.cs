using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var sizes = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            .ToArray();
        var rows = sizes[0];
        var columns = sizes[1];

        // Try using List<HashSet<int>>
        var parkingLot = new char[rows, columns];

        string input;
        input = ParkTheCar(columns, parkingLot);
    }

    private static string ParkTheCar(int columns, char[,] parkingLot)
    {
        string input;
        while ((input = Console.ReadLine()) != "stop")
        {
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var entryRow = args[0];
            var desiredRow = args[1];
            var desiredCol = args[2];

            var distance = Math.Abs(entryRow - desiredRow) + 1;
            distance += desiredCol;

            if (parkingLot[desiredRow, desiredCol] != 'B')
            {
                parkingLot[desiredRow, desiredCol] = 'B';
                Console.WriteLine(distance);
            }
            else
            {
                var parked = false;
                LookForClosestParkSpace(columns, parkingLot, desiredRow, desiredCol, ref distance, ref parked);

                if (!parked)
                {
                    Console.WriteLine($"Row {desiredRow} full");
                }
            }
        }

        return input;
    }

    private static void LookForClosestParkSpace(int columns, char[,] parkingLot, int desiredRow, int desiredCol, ref int distance, ref bool parked)
    {
        var index = 1;
        while (index < columns - 2)
        {
            if (desiredCol - index > 0 && parkingLot[desiredRow, desiredCol - index] != 'B')
            {
                distance--;
                parkingLot[desiredRow, desiredCol - index] = 'B';
                parked = true;
                Console.WriteLine(distance);
                break;
            }

            if (desiredCol + index < columns && parkingLot[desiredRow, desiredCol + index] != 'B')
            {
                distance++;
                parkingLot[desiredRow, desiredCol + index] = 'B';
                parked = true;
                Console.WriteLine(distance);
                break;
            }

            index++;
        }
    }
}