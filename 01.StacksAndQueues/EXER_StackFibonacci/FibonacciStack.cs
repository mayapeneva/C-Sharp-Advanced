using System;
using System.Collections.Generic;

namespace EXER_StackFibonacci
{
    public class FibonacciStack
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            if (n < 2)
            {
                Console.WriteLine(n);
            }
            else if (n == 2)
            {
                Console.WriteLine(1);
            }
            else
            {
                var stack = new Stack<long>();
                stack.Push(1);
                stack.Push(1);
                for (int i = 2; i < n; i++)
                {
                    var tempNumber = stack.Pop();
                    long newNumber = tempNumber + stack.Peek();
                    stack.Push(tempNumber);
                    stack.Push(newNumber);
                }

                Console.WriteLine(stack.Pop());
            }
        }
    }
}
