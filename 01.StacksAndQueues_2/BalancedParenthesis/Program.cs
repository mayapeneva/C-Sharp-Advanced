using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().ToCharArray();

        var stack = new Stack<char>();
        for (int i = 0; i < input.Length; i++)
        {
            var currentChar = input[i];
            if (currentChar == '(' || currentChar == '{'
                || currentChar == '[')
            {
                stack.Push(currentChar);
            }
            else if (stack.Count > 0
                && (currentChar == ')' && stack.Peek() == '('
                || currentChar == '}' && stack.Peek() == '{'
                || currentChar == ']' && stack.Peek() == '['))
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