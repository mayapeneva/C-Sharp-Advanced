using System;

namespace LAB_ParseTags
{
    public class Tags
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var start = "<upcase>";
            var end = "</upcase>";
            while (input.Contains(start) && input.Contains(end))
            {
                var startIndex = input.IndexOf(start);
                input = input.Remove(startIndex, start.Length);

                var endIndex = input.IndexOf(end);
                input = input.Remove(endIndex, end.Length);

                var toBeReplaced = input.Substring(startIndex, endIndex - startIndex);
                var replaced = toBeReplaced.ToUpper();
                input = input.Replace(toBeReplaced, replaced);
            }

            Console.WriteLine(input);
        }
    }
}
