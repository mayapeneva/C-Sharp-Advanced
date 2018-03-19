using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_SortStudents
{
    public class SortStudents
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

            foreach (var student in students.OrderBy(s => s.Split()[1]).ThenByDescending(s => s.Split()[0]))
            {
                Console.WriteLine(student);
            }
        }
    }
}
