using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_GroupByGroup
{
    public class ByGroup
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var students = new List<Person>();
            while (input != "END")
            {
                students.Add(new Person { Name = string.Join(" ", input.Split().Take(2)), Group = int.Parse(string.Join(" ", input.Split().Skip(2))) });

                input = Console.ReadLine();
            }

            foreach (var group in students.OrderBy(s => s.Group).GroupBy(s => s.Group, s => s.Name))
            {
                Console.WriteLine($"{group.Key} - {string.Join(", ", group)}");
            }
        }
    }
}