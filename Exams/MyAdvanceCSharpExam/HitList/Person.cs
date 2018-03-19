using System.Collections.Generic;

public class Person
{
    public Person()
    {
        this.Infos = new Dictionary<string, string>();
    }

    public Dictionary<string, string> Infos { get; set; }

    public int GetPersonsInfoIndex()
    {
        var infoIndex = 0;
        foreach (var info in Infos)
        {
            infoIndex += info.Key.Length;
            infoIndex += info.Value.Length;
        }

        return infoIndex;
    }
}