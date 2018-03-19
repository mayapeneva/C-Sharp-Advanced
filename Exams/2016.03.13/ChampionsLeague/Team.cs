using System.Collections.Generic;

public class Team
{
    public Team(string name)
    {
        this.Opponents = new List<string>();
    }

    public int Wins { get; set; }
    public List<string> Opponents { get; set; }
}