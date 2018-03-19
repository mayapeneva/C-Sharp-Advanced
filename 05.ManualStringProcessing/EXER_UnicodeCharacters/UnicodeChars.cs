using System;

namespace EXER_UnicodeCharacters
{
    public class UnicodeChars
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            foreach (char symbol in input)
            {
                var result = "\\u" + ((int)symbol).ToString("X4").ToLower();
                Console.Write(result);
            }
            Console.WriteLine();
        }
    }
}