using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_BasicStackOperations
{
    public class StackOpers
    {
        public static void Main()
        {
            var operators = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>();
            for (int i = 0; i < operators[0]; i++)
            {
                stack.Push(input[i]);
            }

            for (int j = 0; j < operators[1]; j++)
            {
                stack.Pop();
            }

            if (stack.Contains(operators[2]))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count > 0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
