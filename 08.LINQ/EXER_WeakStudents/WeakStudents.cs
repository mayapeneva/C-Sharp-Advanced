using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_WeakStudents
{
    public class WeakStudents
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

            foreach (var student in students.Where(s => s.Split().Count(t => t == "2") + s.Split().Count(t => t == "3") >= 2))
            {
                Console.WriteLine(string.Join(" ", student.Split().Take(2)));
            }
        }
    }
}
