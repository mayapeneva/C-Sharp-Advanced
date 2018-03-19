using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var bulletPrice = int.Parse(Console.ReadLine());
        var gunBarrelSize = int.Parse(Console.ReadLine());
        var bullets = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
        var locks = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
        var intelligenceValue = int.Parse(Console.ReadLine());

        var bulletsCountAtStart = bullets.Count;
        ShootAllBilletsOut(gunBarrelSize, bullets, locks, bulletsCountAtStart);

        PrintResult(bulletPrice, bullets, locks, intelligenceValue, bulletsCountAtStart);
    }

    private static void PrintResult(int bulletPrice, Stack<int> bullets, Queue<int> locks, int intelligenceValue, int bulletsCountAtStart)
    {
        if (bullets.Count == 0 && locks.Count > 0)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
        else
        {
            var bulletsUsed = bulletsCountAtStart - bullets.Count;
            var moneyEarned = intelligenceValue - (bulletsUsed * bulletPrice);
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
        }
    }

    private static void ShootAllBilletsOut(int gunBarrelSize, Stack<int> bullets, Queue<int> locks, int bulletsCountAtStart)
    {
        var barrelCounter = 0;
        for (int i = 0; i < bulletsCountAtStart; i++)
        {
            var bullet = bullets.Pop();
            var locking = locks.Peek();
            if (bullet <= locking)
            {
                Console.WriteLine("Bang!");
                locks.Dequeue();
            }
            else
            {
                Console.WriteLine("Ping!");
            }

            barrelCounter++;
            if (barrelCounter == gunBarrelSize && bullets.Count > 0)
            {
                Console.WriteLine("Reloading!");
                barrelCounter = 0;
            }

            if (locks.Count == 0)
            {
                break;
            }
        }
    }
}