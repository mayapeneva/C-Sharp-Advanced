using System.Collections.Generic;

public class Department
{
    public Department()
    {
        this.Patients = new List<string>();
    }

    public List<string> Patients { get; set; }
}