namespace LAB_MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class Brackets
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    var index = stack.Pop();
                    var subExpression = input.Substring(index, i - index + 1);
                    Console.WriteLine(subExpression);
                }
            }
        }
    }
}
