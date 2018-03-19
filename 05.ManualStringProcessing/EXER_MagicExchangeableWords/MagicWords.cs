using System;
using System.Collections.Generic;

namespace EXER_MagicExchangeableWords
{
    public class MagicWords
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split();
            var firstWord = words[0].ToCharArray();
            var secondWord = words[1].ToCharArray();

            var letters = new Dictionary<char, char>();
            var length = Math.Min(firstWord.Length, secondWord.Length);
            var magic = true;
            for (int i = 0; i < length; i++)
            {
                var charOne = firstWord[i];
                var charTwo = secondWord[i];
                if (!letters.ContainsKey(charOne))
                {
                    if (letters.ContainsValue(charTwo))
                    {
                        magic = false;
                        break;
                    }

                    letters[charOne] = charTwo;
                }
                else
                {
                    if (letters[charOne] != charTwo)
                    {
                        magic = false;
                        break;
                    }
                }
            }

            if (firstWord.Length > secondWord.Length)
            {
                for (int j = length; j < firstWord.Length; j++)
                {
                    if (!letters.ContainsKey(firstWord[j]))
                    {
                        magic = false;
                        break;
                    }
                }
            }
            else if (firstWord.Length < secondWord.Length)
            {
                for (int k = 0; k < secondWord.Length; k++)
                {
                    if (!letters.ContainsValue(secondWord[k]))
                    {
                        magic = false;
                        break;
                    }
                }
            }

            Console.WriteLine(magic.ToString().ToLower());
        }
    }
}
