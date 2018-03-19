using System;
using System.Text;
using System.Text.RegularExpressions;

namespace EXER_SeriesOfLetters
{
    public class Letters
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var text = Regex.Split(input, string.Empty);

            var result = new StringBuilder(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] != text[i-1])
                {
                    result.Append(text[i]);
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
