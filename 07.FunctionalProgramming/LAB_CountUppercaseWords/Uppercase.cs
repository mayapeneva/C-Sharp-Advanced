using System;
using System.Linq;

namespace LAB_CountUppercaseWords
{
    public class Uppercase
    {
        public static void Main()
        {
            Func<string, bool> findUppercaseword = w => w[0] > 25 & w[0] < 97;
            Action<string> printWord = w => Console.WriteLine(w);

            Console.ReadLine().Split().Where(findUppercaseword).ToList().ForEach(printWord);
        }
    }
}
