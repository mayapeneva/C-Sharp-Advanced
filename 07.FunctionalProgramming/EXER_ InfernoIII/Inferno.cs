using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER__InfernoIII
{
    public class Inferno
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            numbers.Insert(0, 0);
            numbers.Add(0);

            Func<List<int>, int, int, bool> leftSum = (l, i, p) => l[i] + l[i - 1] == p;
            Func<List<int>, int, int, bool> rigthSum = (l, i, p) => l[i] + l[i + 1] == p;
            Func<List<int>, int, int, bool> leftRigthSum = (l, i, p) => l[i] + l[i - 1] + l[i + 1] == p;
            Action<List<int>, int> remover = (l, i) => l.RemoveAt(i);

            var command = Console.ReadLine();
            var commands = new List<string>();
            while (command != "Forge")
            {
                if (command.Split(';')[0] == "Reverse")
                {
                    var comToRemove = command.Replace("Reverse", "Exclude");
                    commands.Remove(comToRemove);
                }
                else
                {
                    commands.Add(command);
                }

                command = Console.ReadLine();
            }

            var numsToBeRemoved = new SortedSet<int>();
            foreach (var tokens in commands)
            {
                var filter = tokens.Split(';');
                var parameter = int.Parse(filter[2]);
                switch (filter[1])
                {
                    case "Sum Left":
                        for (int i = 1; i < numbers.Count - 1; i++)
                        {
                            if (leftSum(numbers, i, parameter))
                            {
                                numsToBeRemoved.Add(i);
                            }
                        }
                        break;
                    case "Sum Right":
                        for (int i = 1; i < numbers.Count - 1; i++)
                        {
                            if (rigthSum(numbers, i, parameter))
                            {
                                numsToBeRemoved.Add(i);
                            }
                        }
                        break;
                    case "Sum Left Right":
                        for (int i = 1; i < numbers.Count - 1; i++)
                        {
                            if (leftRigthSum(numbers, i, parameter))
                            {
                                numsToBeRemoved.Add(i);
                            }
                        }
                        break;
                }
            }

            foreach (var num in numsToBeRemoved.Reverse())
            {
                remover(numbers, num);
            }

            if (numbers[0] == 0)
            {
                numbers.RemoveAt(0);
            }
            if (numbers[numbers.Count - 1] == 0)
            {
                numbers.RemoveAt(numbers.Count - 1);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
