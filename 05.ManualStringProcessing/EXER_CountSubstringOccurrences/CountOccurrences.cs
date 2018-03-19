using System;

namespace EXER_CountSubstringOccurrences
{
    public class CountOccurrences
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var matchingString = Console.ReadLine();

            var counter = 0;
            for (int i = 0; i < text.Length - matchingString.Length + 1; i++)
            {
                var partOfText = text.Substring(i, matchingString.Length);
                if (string.Compare(partOfText, matchingString, true) == 0)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
