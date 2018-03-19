using System.Collections.Generic;

public class Region
{
    public Region(string name)
    {
        this.Name = name;
        this.Meteors = new Dictionary<string, long>(); ;
        this.Meteors["Black"] = 0;
        this.Meteors["Red"] = 0;
        this.Meteors["Green"] = 0;
    }

    public string Name { get; set; }
    public Dictionary<string, long> Meteors { get; set; }

    public void CheckRedMeteors()
    {
        while (this.Meteors["Red"] >= 1000000)
        {
            this.Meteors["Red"] -= 1000000;
            this.Meteors["Black"] += 1;
        }
    }

    public void CheckGreenMeteors()
    {
        while (this.Meteors["Green"] >= 1000000)
        {
            this.Meteors["Green"] -= 1000000;
            this.Meteors["Red"] += 1;
        }

        this.CheckRedMeteors();
    }
}