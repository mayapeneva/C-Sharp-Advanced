using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeStuff_Exercise
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var companies = new List<Company>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Trim('|').Split(new[] {" - "}, StringSplitOptions.RemoveEmptyEntries);
                companies.Add(new Company(input[0], int.Parse(input[1]), input[2]));
            }

            foreach (var company in companies.GroupBy(c => c.Name).OrderBy(c => c.Key))
            {
                var product = company.GroupBy(p => p.Product, p => p.Amount).Select(p => $"{p.Key}-{p.Sum()}");
                Console.WriteLine($"{company.Key}: {string.Join(", ", product)}");
            }
        }
    }
}
