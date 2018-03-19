using System;

namespace EXER_MelrahShake
{
    public class MelrahShake
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (pattern.Length > 0 && text.IndexOf(pattern) != text.LastIndexOf(pattern))
            {
                var firstIndex = text.IndexOf(pattern);
                var lastIndex = text.LastIndexOf(pattern);
                text = text.Remove(lastIndex, pattern.Length);
                text = text.Remove(firstIndex, pattern.Length);
                pattern = pattern.Remove(pattern.Length / 2, 1);
                Console.WriteLine("Shaked it.");
            }

            Console.WriteLine("No shake.");
            Console.WriteLine(text);
        }
    }
}
