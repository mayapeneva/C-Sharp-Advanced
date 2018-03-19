using System;
using System.Linq;

namespace EXER_ParkingSystem
{
    public class Parking
    {
        public static void Main()
        {
            var parkingSize = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var parking = new char[parkingSize[0]][];
            for (int i = 0; i < parkingSize[0]; i++)
            {
                parking[i] = new char[parkingSize[1]];
                for (int j = 0; j < parkingSize[1]; j++)
                {
                    parking[i][j] = 'F';
                }
            }

            var parkingSlot = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            while (parkingSlot[0] != "stop")
            {
                var entryRow = int.Parse(parkingSlot[0]);
                var slotRow = int.Parse(parkingSlot[1]);
                var slotCol = int.Parse(parkingSlot[2]);

                var counter = 1;
                var currentRow = entryRow;
                var currentCol = 0;

                if (parking[slotRow][slotCol] != 'B')
                {
                    FindSlotsRowOrCol(slotRow, ref counter, ref currentRow);

                    FindSlotsRowOrCol(slotCol, ref counter, ref currentCol);

                    parking[currentRow][currentCol] = 'B';
                    Console.WriteLine(counter);
                }
                else
                {
                    var parkingRow = new int[parking[slotRow].Length - 1];
                    var colToPark = 0;
                    FindClosestSlotToPark(parking, slotRow, slotCol, parkingRow);

                    if (parkingRow.Min() == int.MaxValue)
                    {
                        Console.WriteLine($"Row {slotRow} full");
                    }
                    else
                    {
                        for (int colIndex = 0; colIndex < parking[slotRow].Length - 1; colIndex++)
                        {
                            if (parkingRow[colIndex] == parkingRow.Min())
                            {
                                colToPark = colIndex + 1;
                                break;
                            }
                        }

                        FindSlotsRowOrCol(slotRow, ref counter, ref currentRow);

                        FindSlotsRowOrCol(colToPark, ref counter, ref currentCol);

                        parking[currentRow][currentCol] = 'B';
                        Console.WriteLine(counter);
                    }
                }

                parkingSlot = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static void FindClosestSlotToPark(char[][] parking, int slotRow, int slotCol, int[] parkingRow)
        {
            for (int col = 1; col < parking[slotRow].Length; col++)
            {
                if (parking[slotRow][col] != 'B' && col != slotCol)
                {
                    parkingRow[col - 1] = Math.Abs(slotCol - col);
                }
                else
                {
                    parkingRow[col - 1] = int.MaxValue;
                }
            }
        }

        private static void FindSlotsRowOrCol(int slotRowOrCol, ref int counter, ref int currentRowOrCol)
        {
            while (currentRowOrCol != slotRowOrCol)
            {
                if (slotRowOrCol < currentRowOrCol)
                {
                    currentRowOrCol--;
                }
                else
                {
                    currentRowOrCol++;
                }
                counter++;
            }
        }
    }
}
