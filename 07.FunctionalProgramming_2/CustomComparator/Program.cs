using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Func<int[], int[]> evenFunc = a => a.Where(n => n % 2 == 0).ToArray();
        Action<int[]> sort = a => Array.Sort(a);

        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var evens = evenFunc(numbers);
        foreach (var item in evens)
        {
            numbers = numbers.Where(n => n != item).ToArray();
        }

        sort(evens);
        sort(numbers);

        Console.WriteLine($"{string.Join(" ", evens)} {string.Join(" ", numbers)}");
    }
}