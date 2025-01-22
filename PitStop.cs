// Question 2: Pit Stop Strategy Analysis
public class PitStop
{
    public string DriverName { get; set; }
    public int Lap { get; set; }
    public TimeSpan StopTime { get; set; }
    public string TyreCompound { get; set; }
}

public class PitStopAnalysis
{
    public static void Solve()
    {
        List<PitStop> pitStops = new List<PitStop>
        {
            new PitStop { DriverName = "Verstappen", Lap = 15, StopTime = TimeSpan.FromSeconds(2.4), TyreCompound = "Hard" },
            new PitStop { DriverName = "Verstappen", Lap = 35, StopTime = TimeSpan.FromSeconds(2.2), TyreCompound = "Medium" },
            new PitStop { DriverName = "Hamilton", Lap = 14, StopTime = TimeSpan.FromSeconds(2.3), TyreCompound = "Hard" },
            new PitStop { DriverName = "Hamilton", Lap = 36, StopTime = TimeSpan.FromSeconds(2.5), TyreCompound = "Medium" },
            new PitStop { DriverName = "Leclerc", Lap = 13, StopTime = TimeSpan.FromSeconds(2.6), TyreCompound = "Medium" },
            new PitStop { DriverName = "Leclerc", Lap = 34, StopTime = TimeSpan.FromSeconds(2.3), TyreCompound = "Hard" }
        };

        // Tasks:
        // 1. Calculate average pit stop time per driver
        var avgPitStop = pitStops.GroupBy(pitstop => pitstop.DriverName).Select(t => new
        {
            DriverName = t.Key,
            PitStopTime = TimeSpan.FromSeconds(t.Average(stop => stop.StopTime.TotalSeconds))
        });

        foreach (var team in avgPitStop)
        {
            Console.WriteLine($"Driver: {team.DriverName} - Average Pit Stop Time: {team.PitStopTime.TotalSeconds:F3} seconds");
        }

        // 2. Find most used tyre compound per driver
        // var tyreCompound = pitStops.GroupBy(pitstop => pitstop.DriverName);

        // 3. Calculate laps between pit stops for each driver
        var lapsBetweenPitstops = pitStops.GroupBy(driver => driver.DriverName)
            .Select(pit => new
            {
                DriverName = pit.Key,
                LapDifference = pit.OrderBy(p => p.Lap)
                                 .Skip(1)
                                 .Zip(pit.OrderBy(p => p.Lap), (current, previous) => current.Lap - previous.Lap)
                                 .FirstOrDefault()
            });

        foreach (var driver in lapsBetweenPitstops)
        {
            Console.WriteLine($"Driver: {driver.DriverName} - Laps between pit stops: {driver.LapDifference}");
        }

        // 4. Identify drivers who did undercut (pitted before others)
        var firstStops = pitStops
            .GroupBy(p => p.DriverName)
            .Select(g => new
            {
                DriverName = g.Key,
                FirstStopLap = g.OrderBy(p => p.Lap).First().Lap
            })
            .OrderBy(d => d.FirstStopLap);

        Console.WriteLine("\nUndercut Analysis (First Pit Stops):");
        var previousDriver = firstStops.First();
        foreach (var driver in firstStops.Skip(1))
        {
            Console.WriteLine($"{previousDriver.DriverName} undercut {driver.DriverName} by {driver.FirstStopLap - previousDriver.FirstStopLap} laps");
            previousDriver = driver;
        }
    }
}

