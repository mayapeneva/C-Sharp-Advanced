namespace LAB_SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Calculator
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var stack = new Stack<string>(input.Reverse());

            var result = int.Parse(stack.Pop());
            while (stack.Count != 0)
            {
                if (stack.Pop() == "+")
                {
                    result += int.Parse(stack.Pop());
                }
                else
                {
                    result -= int.Parse(stack.Pop());
                }
            }

            Console.WriteLine(result);
        }
    }
}