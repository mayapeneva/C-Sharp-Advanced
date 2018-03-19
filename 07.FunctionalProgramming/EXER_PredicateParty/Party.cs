using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_PredicateParty
{
    public class Party
    {
        public static void Main()
        {
            var nameList = Console.ReadLine().Split().ToList();
            Func<string, string, bool> startingWith = (n, p) => n.StartsWith(p);
            Func<string, string, bool> endingWith = (n, p) => n.EndsWith(p);
            Func<string, int, bool> ifThatLong = (n, p) => n.Length == p;

            var command = Console.ReadLine().Split();
            while (command[0] != "Party!")
            {
                if (command[0] == "Remove")
                {
                    RemoveMatchingNames(nameList, startingWith, endingWith, ifThatLong, command);
                }
                else if (command[0] == "Double")
                {
                    DoubleMatchingNames(nameList, startingWith, endingWith, ifThatLong, command);
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(nameList.Count > 0
                ? $"{string.Join(", ", nameList)} are going to the party!"
                : "Nobody is going to the party!");
        }

        private static void RemoveMatchingNames(List<string> nameList, Func<string, string, bool> startingWith, Func<string, string, bool> endingWith, Func<string, int, bool> ifThatLong, string[] command)
        {
            var parameter = command[2];
            switch (command[1])
            {
                case "StartsWith":
                    nameList.RemoveAll(name => startingWith(name, parameter));
                    break;

                case "EndsWith":
                    nameList.RemoveAll(name => endingWith(name, parameter));
                    break;

                case "Length":
                    nameList.RemoveAll(name => ifThatLong(name, int.Parse(parameter)));
                    break;
            }
        }

        private static void DoubleMatchingNames(List<string> nameList, Func<string, string, bool> startingWith, Func<string, string, bool> endingWith, Func<string, int, bool> ifThatLong, string[] command)
        {
            var parameter = command[2];
            switch (command[1])
            {
                case "StartsWith":
                    for (int i = 0; i < nameList.Count; i++)
                    {
                        var name = nameList[i];
                        if (startingWith(name, parameter))
                        {
                            nameList.Insert(i + 1, name);
                            i++;
                        }
                    }
                    break;

                case "EndsWith":
                    for (int i = 0; i < nameList.Count; i++)
                    {
                        var name = nameList[i];
                        if (endingWith(name, parameter))
                        {
                            nameList.Insert(i + 1, name);
                            i++;
                        }
                    }
                    break;

                case "Length":
                    for (int i = 0; i < nameList.Count; i++)
                    {
                        var name = nameList[i];
                        if (ifThatLong(name, int.Parse(parameter)))
                        {
                            nameList.Insert(i + 1, name);
                            i++;
                        }
                    }
                    break;
            }
        }
    }
}