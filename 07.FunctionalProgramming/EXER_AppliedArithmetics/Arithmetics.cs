using System;
using System.Linq;

namespace EXER_AppliedArithmetics
{
    public class Arithmetics
    {
        public static void Main()
        {
            Func<int, int> addOne = n => n + 1;
            Func<int, int> multiplyByTwo = n => n * 2;
            Func<int, int> substractOne = n => n - 1;
            Action<int[]> printer = n => Console.WriteLine(string.Join(" ", n));

            var numList = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add": numList = numList.Select(x => addOne(x)).ToArray();
                        break;
                    case "multiply": numList = numList.Select(x => multiplyByTwo(x)).ToArray();
                        break;
                    case "subtract": numList = numList.Select(x => substractOne(x)).ToArray();
                        break;
                    case "print": printer(numList);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
