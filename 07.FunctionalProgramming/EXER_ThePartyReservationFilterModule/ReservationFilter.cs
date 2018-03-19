using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_ThePartyReservationFilterModule
{
    public class ReservationFilter
    {
        public static void Main()
        {
            var invitations = Console.ReadLine().Split().ToList();
            Func<string, string, bool> startsWith = (n, p) => n.StartsWith(p);
            Func<string, string, bool> endsWith = (n, p) => n.EndsWith(p);
            Func<string, int, bool> ifThatLong = (n, p) => n.Length == p;
            Func<string, string, bool> ifContains = (n, p) => n.Contains(p);

            var command = Console.ReadLine();
            var commands = new List<string>();
            while (command != "Print")
            {
                if (command.Split(';')[0] == "Remove filter")
                {
                    var comToRemove = command.Replace("Remove", "Add");
                    commands.Remove(comToRemove);
                }
                else
                {
                    commands.Add(command);
                }

                command = Console.ReadLine();
            }

            foreach (var tokens in commands)
            {
                var filter = tokens.Split(';');
                var parameter = filter[2];
                switch (filter[1].ToString())
                {
                    case "Starts with":
                        invitations.RemoveAll(name => startsWith(name, parameter));
                        break;
                    case "Ends with":
                        invitations.RemoveAll(name => endsWith(name, parameter));
                        break;
                    case "Length":
                        invitations.RemoveAll(name => ifThatLong(name, int.Parse(parameter)));
                        break;
                    case "Contains":
                        invitations.RemoveAll(name => ifContains(name, parameter));
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", invitations));
        }
    }
}
