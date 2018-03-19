using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_StudentsByAge
{
    public class StudentsByAge
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

            foreach (var student in students.Where(s => int.Parse(s.Split()[2]) >= 18 && int.Parse(s.Split()[2]) <= 24))
            {
                Console.WriteLine(student);
            }
        }
    }
}
