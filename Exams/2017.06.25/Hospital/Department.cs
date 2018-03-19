using System.Collections.Generic;

public class Department
{
    public Department(string name)
    {
        this.Doctors = new List<string>();
        this.Patients = new List<string>();
    }

    public List<string> Doctors { get; set; }
    public List<string> Patients { get; set; }
}