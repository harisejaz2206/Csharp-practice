using System;
using System.Collections.Generic;
using System.Linq;

public class SectorTime {
    public string DriverName {get; set;}
    public TimeSpan Time{get; set;}
}

public class LapResult {
    public string DriverName{get; set;}
    public TimeSpan LapTime{get; set;}
}

public class F1PracticeAgain {
    public static void Solve() {
        Console.WriteLine("\n=== F1 Lap Times Demo ===\n");

        List<SectorTime> sectorTimes = new List<SectorTime>
        {
            new SectorTime { DriverName = "Verstappen", Time = TimeSpan.FromSeconds(28.2) },
            new SectorTime { DriverName = "Verstappen", Time = TimeSpan.FromSeconds(29.2) },
            new SectorTime { DriverName = "Verstappen", Time = TimeSpan.FromSeconds(27.8) },
            new SectorTime { DriverName = "Hamilton", Time = TimeSpan.FromSeconds(28.7) },
            new SectorTime { DriverName = "Hamilton", Time = TimeSpan.FromSeconds(29.0) },
            new SectorTime { DriverName = "Hamilton", Time = TimeSpan.FromSeconds(28.1) }
        };

        LapResult fastestLap = GetFastestLap(sectorTimes);
        // GetFastestLap(sectorTimes);

        Console.WriteLine($"Fastest Lap: {fastestLap.DriverName} - {fastestLap.LapTime.TotalSeconds:F3} seconds");
    }

    public static LapResult GetFastestLap(List<SectorTime> sectorTimes){
        // Step 1: GroupBy
        Console.WriteLine("Step 1: GroupBy");
        var groupedByDriver = sectorTimes.GroupBy(st => st.DriverName);
        foreach(var group in groupedByDriver){
            Console.WriteLine($"\nDriver: {group.Key}");
            foreach(var sector in group){
                Console.WriteLine($"Sector time: {sector.Time.TotalSeconds:F3} seconds");
            }
        }

        // Step 2: Select
        Console.WriteLine("\nStep 2: Select");
        var driverTotals = groupedByDriver.Select(g => new LapResult
        {
            DriverName = g.Key,
            LapTime = TimeSpan.FromMilliseconds(
                g.Sum(st => st.Time.TotalMilliseconds)
            )
        });

        foreach(var result in driverTotals){
            Console.WriteLine($"Driver: {result.DriverName}, Total Lap Time: {result.LapTime.TotalSeconds.ToString("F3")} seconds");
        }

        // Step 3: OrderBy and First
        var fastestLap = driverTotals.OrderBy(r => r.LapTime).First();
        Console.WriteLine("\nStep 3 - Final Result (After OrderBy and First):");
        // Console.WriteLine($"Fastest Lap: {fastestLap.DriverName} - {fastestLap.LapTime.TotalSeconds.ToString("F3")} seconds");

        return fastestLap;
    }
}
