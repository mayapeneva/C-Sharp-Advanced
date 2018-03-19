using System;
using System.Linq;

namespace EXER_ListOfPredicates
{
    public class Predicates
    {
        public static void Main()
        {
            var lastNumber = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int, bool> ifDivisible = (n, d) => n % d == 0;

            for (int number = 1; number <= lastNumber; number++)
            {
                var predicate = true;
                foreach (var divider in dividers)
                {
                    if (!ifDivisible(number, divider))
                    {
                        predicate = false;
                        break;
                    }
                }

                if (predicate)
                {
                    Console.Write($"{number} ");
                }
            }
            Console.WriteLine();
        }
    }
}
