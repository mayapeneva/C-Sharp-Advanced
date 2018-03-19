using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_StudentsEnrolledIn2014_2015
{
    public class Enrolled2014_2015
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

            foreach (var student in students.Where(s => s.Split()[0].ToString().EndsWith("14") || s.Split()[0].ToString().EndsWith("15")))
            {
                Console.WriteLine(string.Join(" ", student.Split().Skip(1)));
            }
        }
    }
}
