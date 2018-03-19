using System;
using System.Collections.Generic;

namespace EXER_MaximumElement
{
    public class MaxElem
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxNumbers = new Stack<int>();
            maxNumbers.Push(int.MinValue);
            for (int i = 0; i < n; i++)
            {
                var query = Console.ReadLine().Split();
                switch (int.Parse(query[0]))
                {
                    case 1:
                        var number = int.Parse(query[1]);
                        stack.Push(number);
                        if (number > maxNumbers.Peek())
                        {
                            maxNumbers.Push(number);
                        }
                       break;
                    case 2:
                        if (stack.Peek() == maxNumbers.Peek())
                        {
                            if (maxNumbers.Count > 0)
                            {
                                maxNumbers.Pop();
                            }
                        }
                        stack.Pop();
                        break;
                    case 3: Console.WriteLine(maxNumbers.Peek());
                        break;
                }
            }
        }
    }
}
