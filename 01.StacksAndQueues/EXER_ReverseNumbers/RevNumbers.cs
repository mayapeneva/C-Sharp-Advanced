namespace EXER_ReverseNumbers
{
    using System;
    using System.Collections.Generic;

    public class RevNumbers
    {

        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                Console.Write($"{stack.Pop()} ");
            }
            Console.Write(stack.Pop());
            Console.WriteLine();
        }
    }
}
