using System;

namespace EXER_RecursiveFibonacci
{
    public class Recursive
    {
        private static long[] array;

        public static void Main()
        {
            var n = uint.Parse(Console.ReadLine());

            array = new long[n];
            Console.WriteLine(GetFibonacci(n));
        }
        private static long GetFibonacci(uint number)
        {
            if (number <= 2)
            {
                return 1;
            }
            var numberOne = array[number - 2] != 0 ? array[number - 2] : GetFibonacci(number - 1);
            var numberTwo = array[number - 3] != 0 ? array[number - 3] : GetFibonacci(number - 2);
            return array[number - 1] = numberOne + numberTwo; 
        }
    }
}
