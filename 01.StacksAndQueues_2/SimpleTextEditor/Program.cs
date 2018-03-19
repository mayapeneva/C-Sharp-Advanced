using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var text = new StringBuilder();
        var oldText = new Stack<string>();
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            switch (int.Parse(input[0]))
            {
                case 1:
                    oldText.Push(text.ToString());
                    text.Append(input[1]);
                    break;

                case 2:
                    oldText.Push(text.ToString());
                    var count = int.Parse(input[1]);
                    var startIndex = text.Length - count;
                    text.Remove(startIndex, count);
                    break;

                case 3:
                    var number = int.Parse(input[1]);
                    Console.WriteLine(text[number - 1]);
                    break;

                case 4:
                    text.Clear();
                    text.Append(oldText.Pop());
                    break;
            }
        }
    }
}