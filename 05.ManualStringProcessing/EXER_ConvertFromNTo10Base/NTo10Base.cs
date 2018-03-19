using System;
using System.Numerics;

namespace EXER_ConvertFromNTo10Base
{
    public class NTo10Base
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var numBase = int.Parse(input[0]);
            var number = BigInteger.Parse(input[1]);

            BigInteger result = 0;
            for (int i = 0; i < input[1].Length; i++)
            {
                result += (number % 10) * BigInteger.Pow(numBase, i);
                number /= 10;
            }

            Console.WriteLine(result);
        }
    }
}