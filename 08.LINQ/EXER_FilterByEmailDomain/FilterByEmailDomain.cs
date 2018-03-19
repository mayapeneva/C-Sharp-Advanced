using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_FilterByEmailDomain
{
    public class FilterByEmailDomain
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

            foreach (var student in students.Where(s => s.Contains("@gmail.com")))
            {
                Console.WriteLine(string.Join(" ", student.Split().Take(2)));
            }
        }
    }
}
