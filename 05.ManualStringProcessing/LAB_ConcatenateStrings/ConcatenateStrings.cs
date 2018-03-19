using System;
using System.Text;

namespace LAB_ConcatenateStrings
{
    public class ConcatenateStrings
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var result = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();
                result.Append(word).Append(' ');
            }

            result.Remove(result.Length - 1, 1);
            Console.WriteLine(result);
        }
    }
}
