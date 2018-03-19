using System;

namespace EXER_LettersChangeNumbers
{
    public class LettersChangeNums
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var sum = 0M;
            foreach (var str in input)
            {
                var firstLetter = str[0];
                var secondLetter = str[str.Length - 1];
                var number = decimal.Parse(str.Substring(1, str.Length - 2));

                if (firstLetter > 64 && firstLetter < 91)
                {
                    number /= firstLetter - 64;
                }
                else
                {
                    number *= firstLetter - 96;
                }

                if (secondLetter > 64 && secondLetter < 91)
                {
                    number -= secondLetter - 64;
                }
                else
                {
                    number += secondLetter - 96;
                }

                sum += number;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}