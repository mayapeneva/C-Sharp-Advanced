using System;

namespace EXER_StringLength
{
    public class StringLength
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            Console.WriteLine(input.Length < 20 ? input.PadRight(20, '*') : input.Substring(0, 20));
        }
    }
}