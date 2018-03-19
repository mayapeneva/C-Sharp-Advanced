using System;
using System.Linq;

namespace LAB_SpecialWords
{
    public class SpecialWords
    {
        public static void Main()
        {
            var specialWords = Console.ReadLine().Split(new[] {'(', ')', '[', ']', '<', '>', ',', '!', '?', ' '},
                StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine().Split(new[] { '(', ')', '[', ']', '<', '>', ',', '!', '?', ' ' },
                StringSplitOptions.RemoveEmptyEntries); ;

            foreach (var word in specialWords)
            {
                var count = text.Count(w => w == word);
                Console.WriteLine($"{word} - {count}");
            }
        }
    }
}