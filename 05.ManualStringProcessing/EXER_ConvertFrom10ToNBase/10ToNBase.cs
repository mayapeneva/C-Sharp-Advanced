using System;
using System.Numerics;

namespace EXER_ConvertFrom10ToNBase
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var newBase = int.Parse(input[0]);
            var number = BigInteger.Parse(input[1]);

            var result = string.Empty;
            while (number > 0)
            {
                var tempReminder = number / newBase;
                result = Math.Truncate((double)(number - tempReminder * newBase)) + result;
                number = tempReminder;
            }
        
            Console.WriteLine(string.Join("", result));
        }
    }
}
