using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var sizes = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var rows = sizes[0];
        var cols = sizes[1];

        var field = new char[rows][];
        FillTheFieldIn(field, rows, cols);

        long playersMoney = 50;
        var turns = 0;
        var jailturns = 0;
        var hotelIncome = 0;
        for (int r = 0; r < rows; r++)
        {
            if (r % 2 == 0)
            {
                for (int c = 0; c < cols; c++)
                {
                    var step = field[r][c];
                    MakeATurn(cols, ref playersMoney, ref turns, ref jailturns, ref hotelIncome, r, c, step);
                    turns++;
                }
            }
            else
            {
                for (int c = cols - 1; c >= 0; c--)
                {
                    var step = field[r][c];
                    MakeATurn(cols, ref playersMoney, ref turns, ref jailturns, ref hotelIncome, r, c, step);
                    turns++;
                }
            }
        }

        Console.WriteLine($"Turns {turns + jailturns}");
        Console.WriteLine($"Money {playersMoney}");
    }

    private static void MakeATurn(int cols, ref long playersMoney, ref int turns, ref int jailturns, ref int hotelIncome, int row, int col, char step)
    {
        switch (step)
        {
            case 'H':
                hotelIncome += 10;
                Console.WriteLine($"Bought a hotel for {playersMoney}. Total hotels: {hotelIncome / 10}.");
                playersMoney = 0;
                break;

            case 'J':
                Console.WriteLine($"Gone to jail at turn {turns + jailturns}.");
                jailturns += 2;
                playersMoney += 2 * hotelIncome;
                break;

            case 'F':
                break;

            case 'S':
                int product = (row + 1) * (col + 1);
                if (playersMoney > product)
                {
                    Console.WriteLine($"Spent {product} money at the shop.");
                    playersMoney -= product;
                }
                else
                {
                    Console.WriteLine($"Spent {playersMoney} money at the shop.");
                    playersMoney = 0;
                }
                break;
        }

        playersMoney += hotelIncome;
    }

    private static void FillTheFieldIn(char[][] field, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            field[i] = Console.ReadLine().ToCharArray();
        }
    }
}