using System;
using System.Collections.Generic;

namespace LAB_FilterByAge
{
    public class AgeFilter
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var namesList = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var age = int.Parse(input[1]);

                if (!namesList.ContainsKey(name))
                {
                    namesList[name] = 0;
                }

                namesList[name] = age;
            }

            var condition = Console.ReadLine();
            var conditionAge = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();
            foreach (var person in namesList)
            {
                if (condition == "older" && person.Value >= conditionAge)
                {
                    PrintResult(format, person);
                }
                else if (condition == "younger" && person.Value < conditionAge)
                {
                    PrintResult(format, person);
                }
            }
        }

        public static void PrintResult(string format, KeyValuePair<string, int> person)
        {
            if (format == "name age")
            {
                Console.WriteLine($"{person.Key} - {person.Value}");
            }
            else if (format == "name")
            {
                Console.WriteLine(person.Key);
            }
            else if (format == "age")
            {
                Console.WriteLine(person.Value);
            }
        }
    }
}
