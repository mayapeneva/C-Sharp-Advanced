using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_FilterStudentsByPhone
{
    public class FilterByPhone
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

            foreach (var student in students.Where(s => s.Split()[2].StartsWith("02") || s.Split()[2].StartsWith("+3592")))
            {
                Console.WriteLine(string.Join(" ", student.Split().Take(2)));
            }
        }
    }
}
