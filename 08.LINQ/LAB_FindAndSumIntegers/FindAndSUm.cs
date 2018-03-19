using System;
using System.Linq;

namespace LAB_FindAndSumIntegers
{
   public  class FindAndSum
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var result = input.Split()
                .Select(s =>
                {
                    long parsed;
                    var success = long.TryParse(s, out parsed);
                    return new {parsed, success};
                })
                .Where(s => s.success)
                .Select(n => n.parsed)
                .ToList();

            if (result.Count > 0)
            {
                Console.WriteLine(result.Sum());
                return;
            }

            Console.WriteLine("No match");
        }
    }
}
