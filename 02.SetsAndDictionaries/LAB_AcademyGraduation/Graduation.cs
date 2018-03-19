using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB_AcademyGraduation
{
    public class Graduation
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var result = new SortedDictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                var studentName = Console.ReadLine();
                var grades = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                if (!result.ContainsKey(studentName))
                {
                    result[studentName] = new List<double>();
                }

                foreach (var grade in grades)
                {
                    result[studentName].Add(grade);
                }
            }

            foreach (var student in result)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }
        }
    }
}
