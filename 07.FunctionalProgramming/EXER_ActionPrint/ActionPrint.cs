using System;
using System.Linq;

namespace EXER_ActionPrint
{
    public class ActionPrint
    {
        public static void Main()
        {
            Action<string> print = w => Console.WriteLine(w);

            Console.ReadLine().Split().ToList().ForEach(print);
        }
    }
}
