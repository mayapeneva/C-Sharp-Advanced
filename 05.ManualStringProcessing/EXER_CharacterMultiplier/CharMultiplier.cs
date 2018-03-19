using System;

namespace EXER_CharacterMultiplier
{
    public class CharMultiplier
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split();
            var firstWord = words[0].ToCharArray();
            var secondWord = words[1].ToCharArray();

            var sum = 0;
            var length = Math.Min(firstWord.Length, secondWord.Length);
            for (int i = 0; i < length; i++)
            {
                sum += firstWord[i] * secondWord[i];
            }

            if (firstWord.Length > secondWord.Length)
            {
                sum += AddingTheRestOfTheChars(firstWord, length);
            }
            else if (firstWord.Length < secondWord.Length)
            {
                sum += AddingTheRestOfTheChars(secondWord, length);
            }

            Console.WriteLine(sum);
        }

        private static int AddingTheRestOfTheChars(char[] word, int length)
        {
            var sum = 0;
            for (int j = length; j < word.Length; j++)
            {
                sum += word[j];
            }

            return sum;
        }
    }
}
