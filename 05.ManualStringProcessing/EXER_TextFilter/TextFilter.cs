using System;

namespace EXER_TextFilter
{
    public class TextFilter
    {
        public static void Main()
        {
            var banned = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine();
            foreach (string str in banned)
            {
                var index = text.IndexOf(str);
                var toBeReplaced = text.Substring(index, str.Length);
                text = text.Replace(toBeReplaced, new string('*', str.Length));
            }

            Console.WriteLine(text);
        }
    }
}