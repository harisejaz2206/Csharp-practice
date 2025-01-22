using System;
using System.Collections.Generic;
using System.Linq;

public class RaceResult
{
    public string DriverName { get; set; }
    public string Team { get; set; }
    public int Position { get; set; }
    public int Points { get; set; }
    public bool FastestLap { get; set; }
}

public class WinningTeam
{
    public string TeamName { get; set; }
    public int Points { get; set; }
}

public class F1Championship
{
    public static void Solve()
    {
        List<RaceResult> raceResults = new List<RaceResult>
        {
            new RaceResult { DriverName = "Verstappen", Team = "Red Bull", Position = 1, Points = 25, FastestLap = true },
            new RaceResult { DriverName = "Perez", Team = "Red Bull", Position = 3, Points = 15, FastestLap = false },
            new RaceResult { DriverName = "Hamilton", Team = "Mercedes", Position = 2, Points = 18, FastestLap = false },
            new RaceResult { DriverName = "Russell", Team = "Mercedes", Position = 4, Points = 12, FastestLap = false },
            new RaceResult { DriverName = "Leclerc", Team = "Ferrari", Position = 5, Points = 10, FastestLap = false },
            new RaceResult { DriverName = "Sainz", Team = "Ferrari", Position = 6, Points = 8, FastestLap = false }
        };

        // Tasks to implement:

        // 1. Calculate total points per team
        // Expected output format: "Red Bull: 40 points"

        var totalTeamPoints = raceResults.GroupBy(team => team.Team);
        foreach (var team in totalTeamPoints)
        {
            Console.WriteLine($"\nTeam - {team.Key}");
            foreach (var points in team)
            {
                Console.WriteLine($"Points - {points.Points}");
            }
        }

        var totalPointsPerTeam = totalTeamPoints.Select(team => new WinningTeam
        {
            TeamName = team.Key,
            Points = team.Sum(driver => driver.Points)
        });

        foreach (var team in totalPointsPerTeam)
        {
            Console.WriteLine($"\n{team.TeamName}: {team.Points} points");
        }

        // 2. Find teams with podium finishes (Position <= 3)
        // Expected output: List of team names that had at least one driver on podium
        var podiumTeams = raceResults.Where(r => r.Position <= 3).Select(r => r.Team).Distinct();

        Console.WriteLine("\nTeams with podium finishes:");
        foreach (var team in podiumTeams)
        {
            Console.WriteLine(team);
        }

        // 3. Calculate average position per team
        // Expected output format: "Red Bull: 2.0"
        var averagePosition = raceResults.GroupBy(r => r.Team).Select(r => new
        {
            TeamName = r.Key,
            AveragePosition = r.Average(driver => driver.Position)
        });

        foreach (var team in averagePosition)
        {
            Console.WriteLine($"{team.TeamName}: {team.AveragePosition:F1}");
        }

        // 4. Create championship standings including fastest lap bonus point (+1)
        // Expected output format: "1. Verstappen - 26 points"
        var championshipStandings = raceResults.Select(r => new
        {
            DriverName = r.DriverName,
            TotalPoints = r.Points + (r.FastestLap ? 1 : 0)
        })
        .OrderByDescending(r => r.TotalPoints);

        Console.WriteLine("\nChampionship Standings");
        int position = 1;
        foreach (var standing in championshipStandings)
        {
            Console.WriteLine($"{position}. {standing.DriverName} - {standing.TotalPoints}");
            position++;
        }
    }
}