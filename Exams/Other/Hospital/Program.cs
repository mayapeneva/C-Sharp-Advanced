using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var hospital = new Dictionary<string, Department>();
        var doctors = new Dictionary<string, Doctor>();

        string input;
        while ((input = Console.ReadLine()) != "Output")
        {
            var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var departmentName = tokens[0];
            var doctorName = $"{tokens[1]} {tokens[2]}";
            var patientName = tokens[3];

            if (!hospital.ContainsKey(departmentName))
            {
                hospital[departmentName] = new Department();
            }

            if (hospital[departmentName].Patients.Count < 60)
            {
                hospital[departmentName].Patients.Add(patientName);
            }

            if (!doctors.ContainsKey(doctorName))
            {
                doctors[doctorName] = new Doctor();
            }

            doctors[doctorName].Patients.Add(patientName);
        }

        while ((input = Console.ReadLine()) != "End")
        {
            var command = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (command.Length == 1)
            {
                foreach (var patient in hospital[command[0]].Patients)
                {
                    Console.WriteLine(patient);
                }
            }
            else
            {
                var result = new List<string>();
                var room = 0;
                var ifParsed = int.TryParse(command[1], out room);
                if (ifParsed)
                {
                    var start = (room - 1) * 3;
                    for (int i = start; i < start + 3; i++)
                    {
                        result.Add(hospital[command[0]].Patients[i]);
                    }
                }
                else
                {
                    var name = $"{command[0]} {command[1]}";
                    foreach (var patient in doctors[name].Patients)
                    {
                        result.Add(patient);
                    }
                }

                foreach (var item in result.OrderBy(p => p))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}