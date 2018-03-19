using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var hospital = new Dictionary<string, Department>();
        string output;
        while ((output = Console.ReadLine()) != "Output")
        {
            var args = output.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var department = args[0];
            var doctor = args[1] + ' ' + args[2];
            var patient = args[3];
            if (!hospital.ContainsKey(department))
            {
                hospital[department] = new Department(department);
            }

            if (hospital[department].Patients.Count < 60)
            {
                hospital[department].Doctors.Add(doctor);
                hospital[department].Patients.Add(patient);
            }
        }

        var result = new List<string>();
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var argss = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (argss.Length == 1)
            {
                var dept = hospital[argss[0]];
                foreach (string patient in dept.Patients)
                {
                    Console.WriteLine(patient);
                }
            }
            else
            {
                var roomNumber = 0;
                var ifParsed = int.TryParse(argss[1], out roomNumber);
                if (ifParsed)
                {
                    var dept = hospital[argss[0]];
                    var start = (roomNumber - 1) * 3;
                    for (int i = start; i < start + 3; i++)
                    {
                        if (i < dept.Patients.Count)
                        {
                            result.Add(dept.Patients[i]);
                        }
                    }

                    foreach (var p in result.OrderBy(p => p))
                    {
                        Console.WriteLine(p);
                    }
                }
                else
                {
                    var dName = argss[0] + ' ' + argss[1];
                    foreach (var department in hospital.Values)
                    {
                        for (int i = 0; i < department.Doctors.Count; i++)
                        {
                            if (department.Doctors[i].Equals(dName))
                            {
                                result.Add(department.Patients[i]);
                            }
                        }
                    }

                    foreach (var p in result.OrderBy(p => p))
                    {
                        Console.WriteLine(p);
                    }
                }
            }
        }
    }
}