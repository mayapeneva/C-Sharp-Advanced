using System;
using System.Collections.Generic;

namespace EXER_StudentsByNames
{
    public class StudentsByNames
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var students = new List<string>();
            while (input != "END")
            {
                students.Add(input);

                input = Console.ReadLine();
            }

            students.ForEach(s =>
            {
                var tokens = s.Split();
                var firstName = tokens[0];
                var lastName = tokens[1];
                for (int i = 0; i < Math.Min(firstName.Length, lastName.Length); i++)
                {
                    if (firstName[i] < lastName[i])
                    {
                        Console.WriteLine(s);
                        break;
                    }

                    if (firstName[i] > lastName[i])
                    {
                        break;
                    }
                }
            });
        }
    }
}