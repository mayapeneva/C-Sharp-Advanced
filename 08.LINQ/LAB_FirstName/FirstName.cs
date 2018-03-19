using System;
using System.Linq;

namespace LAB_FirstName
{
    public class FirstName
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var letters = Console.ReadLine().Split().Select(s => s.ToLower()).OrderBy(l => l).ToArray();

            foreach (string letter in letters)
            {
                var result = input.FirstOrDefault(w => w.ToLower()[0] == letter[0]);
                if (result != null)
                {
                    Console.WriteLine(result);
                    return;
                }
            }

            Console.WriteLine("No match");
        }
    }
}