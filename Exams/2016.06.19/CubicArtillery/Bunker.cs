using System.Collections.Generic;

public class Bunker
{
    public Bunker(char name)
    {
        this.Name = name;
        this.Weapons = new Queue<int>();
    }

    public char Name { get; set; }
    public Queue<int> Weapons { get; set; }
    public int Capacity { get; set; }
}