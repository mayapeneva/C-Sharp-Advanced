using System;
using System.Collections.Generic;

namespace EXER_MultiplyBigNumber
{
    public class BigMultiply
    {
        public static void Main()
        {
            var number = Console.ReadLine();
            var multiplier = int.Parse(Console.ReadLine());

            if (number == "0" || multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var reminder = 0;
            var result = new Stack<int>();
            for (int i = number.Length - 1; i >= 0; i--)
            {
                var tempResult = ((number[i] - 48) * multiplier) + reminder;
                if (tempResult.ToString().Length > 1)
                {
                    reminder = tempResult / 10;
                    tempResult -= reminder * 10;
                }
                else
                {
                    reminder = 0;
                }

                result.Push(tempResult);
            }

            if (reminder > 0)
            {
                result.Push(reminder);
            }

            var final = string.Join("", result.ToArray());
            Console.WriteLine(final);
        }
    }
}
