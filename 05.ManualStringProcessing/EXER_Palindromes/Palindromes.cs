using System;
using System.Collections.Generic;

namespace EXER_Palindromes
{
    public class Palindromes
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new []{' ', ',', '.', '?', '!'}, StringSplitOptions.RemoveEmptyEntries);
            
            var result = new SortedSet<string>();
            for (int i = 0; i < input.Length; i++)
            {
                var word = input[i].ToCharArray();
                var index = word.Length - 1;
                var palindrome = true;
                for (int j = 0; j < word.Length/2; j++)
                {
                    if (word[j] != word[index])
                    {
                        palindrome = false;
                        break;
                    }

                    index--;
                }

                if (palindrome)
                {
                    result.Add(string.Join("", word));
                }
            }

            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
    }
}
