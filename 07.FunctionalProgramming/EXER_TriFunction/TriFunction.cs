using System;
using System.Linq;

namespace EXER_TriFunction
{
    public class TriFunction
    {
        public static void Main()
        {
            var border = double.Parse(Console.ReadLine());
            var nameList = Console.ReadLine().Split();

            Func<char, int> turnToDigit = c => c;
            Func<string, double, Func<char, int>, bool> sumIsBigger = (n, b, f) => n.ToCharArray().Select(c => f(c)).Sum() >= b;

            foreach (var name in nameList)
            {
                if (sumIsBigger(name, border, turnToDigit))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }
    }
}