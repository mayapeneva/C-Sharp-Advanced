using System;
using System.Collections.Generic;

namespace EXER_CountSymbols
{
    public class SymbolsCount
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();

            var result = new SortedDictionary<char, int>();
            foreach (var symbol in input)
            {
                if (!result.ContainsKey(symbol))
                {
                    result[symbol] = 0;
                }

                result[symbol]++;
            }

            foreach (var tocken in result)
            {
                Console.WriteLine($"{tocken.Key}: {tocken.Value} time/s");
            }
        }
    }
}
