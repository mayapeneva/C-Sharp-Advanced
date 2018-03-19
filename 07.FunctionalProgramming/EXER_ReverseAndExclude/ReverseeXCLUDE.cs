using System;
using System.Linq;

namespace EXER_ReverseAndExclude
{
    public class Program
    {
        public static void Main()
        {
            var collection = Console.ReadLine().Split().Select(int.Parse).ToList();
            var divider = int.Parse(Console.ReadLine());

            Predicate<int> excluder = n => n % divider == 0;

            for (int i = collection.Count - 1; i >= 0; i--)
            {
                var number = collection[i];
                if (excluder(number))
                {
                    collection.Remove(number);
                }
            }

            collection.Reverse();
            Console.WriteLine(string.Join(" ", collection));
        }
    }
}
