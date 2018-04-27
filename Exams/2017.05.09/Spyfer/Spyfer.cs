namespace Spyfer
{
    using System;
    using System.Linq;

    public class Spyfer
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 1; i < input.Count - 1; i++)
            {
                if (input[i] == input[i-1] + input[i+1])
                {
                    input.RemoveAt(i+1);
                    input.RemoveAt(i-1);
                    i = 0;
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
