using System;
using System.Collections.Generic;

public class Driver
{
    public int DriverId { get; set; }
    public string Name { get; set; }
    public string Nationality { get; set; }
    public int Number { get; set; }
    public string TeamId { get; set; }
    public int ChampionshipWins { get; set; }
    public bool IsActive { get; set; }
}

public class Race
{
    public int RaceId { get; set; }
    public string GrandPrix { get; set; }
    public DateTime RaceDate { get; set; }
    public int Laps { get; set; }
    public string Circuit { get; set; }
}

public class F1RaceResult
{
    public int RaceId { get; set; }
    public int DriverId { get; set; }
    public int Position { get; set; }
    public int Points { get; set; }
    public bool FastestLap { get; set; }
    public string Status { get; set; } // "Finished", "DNF", "DSQ"
}

public class Team
{
    public string TeamId { get; set; }
    public string Name { get; set; }
    public string BaseLocation { get; set; }
    public int ChampionshipWins { get; set; }
    public string PowerUnit { get; set; }
}

public class F1Data
{
    public static void Solve()
    {
        // Sample Data
        var drivers = new List<Driver>
        {
            new Driver { DriverId = 1, Name = "Max Verstappen", Nationality = "Dutch", Number = 1, TeamId = "RBR", ChampionshipWins = 3, IsActive = true },
            new Driver { DriverId = 2, Name = "Sergio Perez", Nationality = "Mexican", Number = 11, TeamId = "RBR", ChampionshipWins = 0, IsActive = true },
            new Driver { DriverId = 3, Name = "Daniel Ricciardo", Nationality = "Australian", Number = 3, TeamId = "RBV", ChampionshipWins = 0, IsActive = true },
            new Driver { DriverId = 4, Name = "Sebastian Vettel", Nationality = "German", Number = 5, TeamId = "RBR", ChampionshipWins = 4, IsActive = false },
            new Driver { DriverId = 5, Name = "Mark Webber", Nationality = "Australian", Number = 2, TeamId = "RBR", ChampionshipWins = 0, IsActive = false }
        };

        var races = new List<Race>
        {
            new Race { RaceId = 1, GrandPrix = "Bahrain", RaceDate = new DateTime(2024, 3, 2), Laps = 57, Circuit = "Bahrain International Circuit" },
            new Race { RaceId = 2, GrandPrix = "Saudi Arabia", RaceDate = new DateTime(2024, 3, 9), Laps = 50, Circuit = "Jeddah Corniche Circuit" },
            new Race { RaceId = 3, GrandPrix = "Australia", RaceDate = new DateTime(2024, 3, 24), Laps = 58, Circuit = "Albert Park Circuit" },
            new Race { RaceId = 4, GrandPrix = "Japan", RaceDate = new DateTime(2024, 4, 7), Laps = 53, Circuit = "Suzuka Circuit" },
            new Race { RaceId = 5, GrandPrix = "Miami", RaceDate = new DateTime(2024, 5, 5), Laps = 57, Circuit = "Miami International Autodrome" }
        };

        var raceResults = new List<F1RaceResult>
        {
            new F1RaceResult { RaceId = 1, DriverId = 1, Position = 1, Points = 25, FastestLap = true, Status = "Finished" },
            new F1RaceResult { RaceId = 1, DriverId = 2, Position = 2, Points = 18, FastestLap = false, Status = "Finished" },
            new F1RaceResult { RaceId = 2, DriverId = 1, Position = 1, Points = 25, FastestLap = false, Status = "Finished" },
            new F1RaceResult { RaceId = 2, DriverId = 2, Position = 4, Points = 12, FastestLap = false, Status = "Finished" },
            new F1RaceResult { RaceId = 3, DriverId = 1, Position = 0, Points = 0, FastestLap = false, Status = "DNF" },
            new F1RaceResult { RaceId = 3, DriverId = 2, Position = 5, Points = 10, FastestLap = false, Status = "Finished" },
            new F1RaceResult { RaceId = 4, DriverId = 1, Position = 1, Points = 25, FastestLap = true, Status = "Finished" },
            new F1RaceResult { RaceId = 4, DriverId = 2, Position = 2, Points = 18, FastestLap = false, Status = "Finished" },
            new F1RaceResult { RaceId = 5, DriverId = 1, Position = 1, Points = 25, FastestLap = false, Status = "Finished" },
            new F1RaceResult { RaceId = 5, DriverId = 2, Position = 0, Points = 0, FastestLap = false, Status = "DNF" }
        };

        var teams = new List<Team>
        {
            new Team { TeamId = "RBR", Name = "Red Bull Racing", BaseLocation = "Milton Keynes", ChampionshipWins = 6, PowerUnit = "Honda RBPT" },
            new Team { TeamId = "RBV", Name = "Racing Bulls", BaseLocation = "Faenza", ChampionshipWins = 0, PowerUnit = "Honda RBPT" }
        };

        // Example logic to display data
        foreach (var driver in drivers)
        {
            Console.WriteLine($"Driver: {driver.Name}, Team: {driver.TeamId}, Wins: {driver.ChampionshipWins}");
        }
    }
}
