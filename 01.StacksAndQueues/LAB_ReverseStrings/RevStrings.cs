namespace LAB_ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class RevStrings
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
