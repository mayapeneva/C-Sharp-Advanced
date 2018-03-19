using System;
using System.Collections.Generic;
using System.Linq;

namespace EXER_StudentsJoinedSpecialties
{
    public class Specialties
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var specialities = new List<Specialty>();
            while (input != "Students:")
            {
                var specTokens = input.Split();
                specialities.Add(new Specialty
                {
                    SpecialityName = string.Join(" ", specTokens.Take(specTokens.Length - 1)),
                    FacultyNumber = specTokens[specTokens.Length - 1]
                });

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            var students = new List<Student>();
            while (input != "END")
            {
                var studTokens = input.Split();
                students.Add(new Student
                {
                    StudentName = string.Join(" ", studTokens.Skip(1)),
                    FacultyNumber = studTokens[0]
                });

                input = Console.ReadLine();
            }

            var result = students
                .GroupJoin(
                specialities, st => st.FacultyNumber, sp => sp.FacultyNumber,
                (stud, res) => new
                {
                    name = stud.StudentName,
                    number = stud.FacultyNumber,
                    allSpec = res
                });

            foreach (var item in result.OrderBy(s => s.name))
            {
                foreach (var spec in item.allSpec)
                {
                    Console.WriteLine($"{item.name} {item.number} {spec.SpecialityName}");
                }
            }
        }
    }
}
