using System;
using System.Linq;

namespace EXER_CustomMinFunction
{
    public class MinFunction
    {
        public static void Main()
        {
            Func<string, int> numberParser = n => int.Parse(n);

            Console.WriteLine(Console.ReadLine().Split().Select(numberParser).ToList().Min());
        }
    }
}
