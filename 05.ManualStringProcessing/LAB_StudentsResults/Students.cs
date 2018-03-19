using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB_StudentsResults
{
    public class Students
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var students = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {'-', ','}, StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var firstGrade = double.Parse(input[1]);
                var secondGrade = double.Parse(input[2]);
                var thirdGrade = double.Parse(input[3]);

                if (!students.ContainsKey(name))
                {
                    students[name] = new List<double>();
                }

                students[name].Add(firstGrade);
                students[name].Add(secondGrade);
                students[name].Add(thirdGrade);
            }

            Console.WriteLine(string.Format("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", 
                "Name", "CAdv", "COOP", "AdvOOP", "Average"));

            foreach (var student in students)
            {
                Console.WriteLine(string.Format("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|", 
                    student.Key, student.Value[0], student.Value[1], student.Value[2], student.Value.Average()));
            }
        }
    }
}
