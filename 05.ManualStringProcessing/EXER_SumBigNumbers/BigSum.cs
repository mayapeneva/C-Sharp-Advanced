using System;
using System.Collections.Generic;

namespace EXER_SumBigNumbers
{
    public class BigSum
    {
        public static void Main()
        {
            var firstNumber = Console.ReadLine();
            var secondNumber = Console.ReadLine();

            if (firstNumber.Length > secondNumber.Length)
            {
                secondNumber = secondNumber.PadLeft(firstNumber.Length, '0');
            }
            else if (firstNumber.Length < secondNumber.Length)
            {
                firstNumber = firstNumber.PadLeft(secondNumber.Length, '0');
            }

            var reminder = 0;
            var result = new Stack<int>();
            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                var sum = (firstNumber[i] - 48) + (secondNumber[i] - 48) + reminder;
                if (sum.ToString().Length > 1)
                {
                    reminder = sum/10;
                    sum -= reminder * 10;
                }
                else
                {
                    reminder = 0;
                }

                result.Push(sum);
            }

            if (reminder > 0)
            {
                result.Push(reminder);
            }

            var final = string.Join("", result.ToArray());
            Console.WriteLine(final.TrimStart('0'));
        
        }
    }
}
