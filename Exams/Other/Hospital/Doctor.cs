using System.Collections.Generic;

public class Doctor
{
    public Doctor()
    {
        this.Patients = new List<string>();
    }

    public List<string> Patients { get; set; }
}