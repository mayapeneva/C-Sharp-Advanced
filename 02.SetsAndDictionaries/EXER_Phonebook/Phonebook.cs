using System;
using System.Collections.Generic;

namespace EXER_Phonebook
{
    public class Phonebook
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {"-"}, StringSplitOptions.RemoveEmptyEntries);

            var result = new Dictionary<string, string>();
            while (input[0] != "search")
            {
                var name = input[0];
                if (!result.ContainsKey(name))
                {
                    result[name] = string.Empty;
                }

                result[name] = input[1];

                input = Console.ReadLine().Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            }

            input = Console.ReadLine().Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "stop")
            {
                var searchName = input[0];
                if (result.ContainsKey(searchName))
                {
                    Console.WriteLine($"{searchName} -> {result[searchName]}");
                }
                else
                {
                    Console.WriteLine($"Contact {searchName} does not exist.");
                }

                input = Console.ReadLine().Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
