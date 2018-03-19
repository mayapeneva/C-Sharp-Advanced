using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_StudentsByGroup
{
    public class GroupStudents
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

            foreach (var student in students.Where(s => int.Parse(s.Split()[2]) == 2).OrderBy(s => s.Split()[0]))
            {
                Console.WriteLine(string.Join(" ", student.Split().Take(2)));
            }
        }
    }
}
