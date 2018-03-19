using System;
using System.Collections.Generic;

namespace EXER_MinerTask
{
    public class MinerTask
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var result = new Dictionary<string, int>();
            while (input != "stop")
            {
                if (!result.ContainsKey(input))
                {
                    result[input] = 0;
                }

                var inputTwo = Console.ReadLine();
                result[input] += int.Parse(inputTwo);

                input = Console.ReadLine();
            }

            foreach (var resource in result)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
