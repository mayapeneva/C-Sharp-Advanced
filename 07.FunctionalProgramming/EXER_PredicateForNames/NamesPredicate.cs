using System;
using System.Linq;

namespace EXER_PredicateForNames
{
    public class NamesPredicate
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Predicate<string> lengthMesurer = s => s.Length <= n;
            Action<string> printer = s => Console.WriteLine(s);

            var names = Console.ReadLine().Split().ToList();
            foreach (var name in names)
            {
                if (lengthMesurer(name))
                {
                    printer(name);
                }
            }
        }
    }
}