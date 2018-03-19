using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_ExcellentStudents
{
    public class ExcellentStudents
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

            foreach (var student in students.Where(s => s.Contains("6")))
            {
                Console.WriteLine(string.Join(" ", student.Split().Take(2)));
            }
        }
    }
}
