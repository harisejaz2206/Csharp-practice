// Question 3: Qualifying Analysis
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

public class QualifyingLap
{
    public string DriverName { get; set; }
    public int Session { get; set; }  // 1=Q1, 2=Q2, 3=Q3
    public TimeSpan LapTime { get; set; }
    public bool ValidLap { get; set; }
    public string TrackCondition { get; set; }
}

public class QualifyingAnalysis
{
    public static void Solve()
    {
        List<QualifyingLap> qualifyingLaps = new List<QualifyingLap>
        {
            new QualifyingLap { DriverName = "Verstappen", Session = 1, LapTime = TimeSpan.FromSeconds(80.5), ValidLap = true, TrackCondition = "Dry" },
            new QualifyingLap { DriverName = "Verstappen", Session = 2, LapTime = TimeSpan.FromSeconds(80.2), ValidLap = true, TrackCondition = "Dry" },
            new QualifyingLap { DriverName = "Verstappen", Session = 3, LapTime = TimeSpan.FromSeconds(79.8), ValidLap = true, TrackCondition = "Dry" },
            new QualifyingLap { DriverName = "Hamilton", Session = 1, LapTime = TimeSpan.FromSeconds(80.7), ValidLap = true, TrackCondition = "Dry" },
            new QualifyingLap { DriverName = "Hamilton", Session = 2, LapTime = TimeSpan.FromSeconds(80.1), ValidLap = true, TrackCondition = "Dry" },
            new QualifyingLap { DriverName = "Hamilton", Session = 3, LapTime = TimeSpan.FromSeconds(80.0), ValidLap = false, TrackCondition = "Wet" }
        };

        // Tasks:
        // 1. Find fastest valid lap time per session for each driver
        var fastestLap = qualifyingLaps
            .Where(lap => lap.ValidLap)
            .GroupBy(driver => driver.DriverName)
            .Select(p => new
            {
                Driver = p.Key,
                FastestLapTime = p.OrderBy(p => p.LapTime).First().LapTime
            });

        foreach (var lap in fastestLap)
        {
            Console.WriteLine($"Driver Name:{lap.Driver} - Fastest Lap Time {lap.FastestLapTime.TotalMinutes:F3}");
        }


        // 2. Calculate gap to pole position (fastest valid lap in Q3)
        var gapToPole = qualifyingLaps
            .Where(lap => lap.Session == 3 && lap.ValidLap)
            .OrderBy(lap => lap.LapTime)
            .Take(2)
            .Select(lap => new
            {
                Driver = lap.DriverName,
                LapTimes = lap.LapTime
            })
            .ToList(); // Convert to a list to access elements later

        // Output the results
        foreach (var laps in gapToPole)
        {
            Console.WriteLine($"Driver: {laps.Driver} - Lap: {laps.LapTimes.TotalSeconds:F3}");
        }

        // Calculate the difference between the two lap times
        if (gapToPole.Count == 2) // Ensure there are two drivers
        {
            var firstLapTime = gapToPole[0].LapTimes; // Fastest lap time
            var secondLapTime = gapToPole[1].LapTimes; // Second fastest lap time

            // Calculate the absolute difference
            var lapDifference = Math.Abs((firstLapTime - secondLapTime).TotalSeconds);

            Console.WriteLine($"Lap Time Difference: {lapDifference:F3} seconds");
        }

        // 3. Find drivers who improved their times in each session
        var improvedDrivers = qualifyingLaps
            .GroupBy(lap => lap.DriverName)
            .Select(driver => new
            {
                DriverName = driver.Key,
                Q1Time = driver.Where(l => l.Session == 1 && l.ValidLap).Min(l => l.LapTime),
                Q2Time = driver.Where(l => l.Session == 2 && l.ValidLap).Min(l => l.LapTime),
                Q3Time = driver.Where(l => l.Session == 3 && l.ValidLap).Min(l => l.LapTime),
            })
            .Where(d => d.Q2Time < d.Q1Time && d.Q3Time < d.Q2Time);

        foreach (var driver in improvedDrivers)
        {
            Console.WriteLine($"\nDriver {driver.DriverName} improved each session:");
            Console.WriteLine($"Q1: {driver.Q1Time.TotalSeconds:F3}s");
            Console.WriteLine($"Q2: {driver.Q2Time.TotalSeconds:F3}s");
            Console.WriteLine($"Q3: {driver.Q3Time.TotalSeconds:F3}s");
        }


        // 4. Group drivers by their best session performance
        var bestSessionPerformance = qualifyingLaps
            .Where(lap => lap.ValidLap)
            .GroupBy(lap => lap.DriverName)
            .Select(driverGroup => new
            {
                DriverName = driverGroup.Key,
                BestLapTime = new
                {
                    Q1 = driverGroup.Where(l => l.Session == 1).Min(l => l.LapTime),
                    Q2 = driverGroup.Where(l => l.Session == 2).Min(l => l.LapTime),
                    Q3 = driverGroup.Where(l => l.Session == 3).Min(l => l.LapTime)
                }
            })
            .Select(driver => new
            {
                driver.DriverName,
                driver.BestLapTime,
                OverallBestLapTime = new[]
                {
                    driver.BestLapTime.Q1,
                    driver.BestLapTime.Q2,
                    driver.BestLapTime.Q3
                }.Min()
            })
            .OrderBy(driver => driver.OverallBestLapTime);

        foreach (var driver in bestSessionPerformance)
        {
            Console.WriteLine($"\nDriver {driver.DriverName} - Best Session Performance:");
            Console.WriteLine($"Q1: {driver.BestLapTime.Q1.TotalSeconds:F3}s");
            Console.WriteLine($"Q2: {driver.BestLapTime.Q2.TotalSeconds:F3}s");
            Console.WriteLine($"Q3: {driver.BestLapTime.Q3.TotalSeconds:F3}s");
            Console.WriteLine($"Overall Best Lap Time: {driver.OverallBestLapTime.TotalSeconds:F3}s");
        }
    }
}