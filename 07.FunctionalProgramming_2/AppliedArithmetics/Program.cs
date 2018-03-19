using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Func<int[], int[]> add = l => l.Select(n => n + 1).ToArray();
        Func<int[], int[]> multiply = l => l.Select(n => n * 2).ToArray();
        Func<int[], int[]> subtract = l => l.Select(n => n - 1).ToArray();
        Action<int[]> print = l => Console.WriteLine(string.Join(" ", l));

        var numbers = Console.ReadLine().Split().Select(int.Parse)
            .ToArray();

        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            switch (input)
            {
                case "add":
                    numbers = add(numbers);
                    break;

                case "multiply":
                    numbers = multiply(numbers);
                    break;

                case "subtract":
                    numbers = subtract(numbers);
                    break;

                case "print":
                    print(numbers);
                    break;
            }
        }
    }
}