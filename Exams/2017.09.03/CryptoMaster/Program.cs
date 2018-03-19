using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var counter = 1;
        for (int start = 0; start < numbers.Length; start++)
        {
            for (int step = 1; step < numbers.Length; step++)
            {
                var startNumber = numbers[start];
                var tempCounter = 1;
                var currentIndex = (start + step) % numbers.Length;

                while (numbers[currentIndex] > startNumber)
                {
                    startNumber = numbers[currentIndex];
                    currentIndex = (currentIndex + step) % numbers.Length;

                    tempCounter++;
                }

                if (tempCounter > counter)
                {
                    counter = tempCounter;
                }
            }
        }

        Console.WriteLine(counter);
    }
}