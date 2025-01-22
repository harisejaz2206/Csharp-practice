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
        // 2. Find most used tyre compound per driver
        // 3. Calculate laps between pit stops for each driver
        // 4. Identify drivers who did undercut (pitted before others)
    }
}

