using System;

namespace EXER_FormattingNumbers
{
    public class FormattingNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new []{' ', '\t', '\n', 'r'}, StringSplitOptions.RemoveEmptyEntries);
            var firstNumber = int.Parse(input[0]);
            var secondNumber = $"{double.Parse(input[1]):f2}";
            var thirdNumber = $"{double.Parse(input[2]):f3}";

            var hexadecimalNumber = $"{Convert.ToString(firstNumber, 16)}";
            var binaryNumber = Convert.ToString(firstNumber, 2).PadLeft(10, '0').Substring(0, 10);


            Console.WriteLine($"|{hexadecimalNumber.ToUpper(), -10}|{binaryNumber}|{secondNumber, 10}|{thirdNumber, -10}|");
        }
    }
}
