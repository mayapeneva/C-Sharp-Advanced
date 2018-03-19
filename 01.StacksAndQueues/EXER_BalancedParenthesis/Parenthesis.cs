using System;
using System.Collections.Generic;

namespace EXER_BalancedParenthesis
{
    public class Parenthesis
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();

            var stack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                var symbol = input[i];
                if (symbol == '(' || symbol == '{' || symbol == '[')
                {
                    stack.Push(symbol);
                }
                else if (stack.Count > 0 && ((symbol == ')' && stack.Peek() == '(')
                    || (symbol == '}' && stack.Peek() == '{')
                    || (symbol == ']' && stack.Peek() == '[')))
                {
                    stack.Pop();
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            Console.WriteLine("YES");
        }
    }
}
