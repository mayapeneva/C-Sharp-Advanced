using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var teams = new Dictionary<string, Team>();

        string input;
        while ((input = Console.ReadLine()) != "stop")
        {
            var tokens = input.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var team1Name = tokens[0];
            var team2Name = tokens[1];
            var firstMatchScores = tokens[2].Split(':');
            var secondMatchScores = tokens[3].Split(':');
            var scoreTeam1OwnSoil = int.Parse(firstMatchScores[0]);
            var scoreTeam2AwaySoil = int.Parse(firstMatchScores[1]);
            var scoreTeam2OwnSoil = int.Parse(secondMatchScores[0]);
            var scoreTeam1AwaySoil = int.Parse(secondMatchScores[1]);

            if (!teams.ContainsKey(team1Name))
            {
                teams[team1Name] = new Team(team1Name);
            }

            teams[team1Name].Opponents.Add(team2Name);

            if (!teams.ContainsKey(team2Name))
            {
                teams[team2Name] = new Team(team2Name);
            }

            teams[team2Name].Opponents.Add(team1Name);

            if (scoreTeam1AwaySoil + scoreTeam1OwnSoil > scoreTeam2AwaySoil + scoreTeam2OwnSoil)
            {
                teams[team1Name].Wins++;
            }
            else if (scoreTeam1AwaySoil + scoreTeam1OwnSoil < scoreTeam2AwaySoil + scoreTeam2OwnSoil)
            {
                teams[team2Name].Wins++;
            }
            else
            {
                if (scoreTeam1AwaySoil > scoreTeam2AwaySoil)
                {
                    teams[team1Name].Wins++;
                }
                else if (scoreTeam1AwaySoil < scoreTeam2AwaySoil)
                {
                    teams[team2Name].Wins++;
                }
            }
        }

        foreach (var team in teams.OrderByDescending(t => t.Value.Wins).ThenBy(t => t.Key))
        {
            Console.WriteLine(team.Key);
            Console.WriteLine($"- Wins: {team.Value.Wins}");
            Console.WriteLine($"- Opponents: {string.Join(", ", team.Value.Opponents.OrderBy(o => o))}");
        }
    }
}