// public class SectorTime
// {
//     public string DriverName { get; set; }
//     public TimeSpan Time { get; set; }
// }

// public class LapResult
// {
//     public string DriverName { get; set; }
//     public TimeSpan LapTime { get; set; }
// }

// public class F1Practice
// {
//     public static void Solve()
//     {
//         Console.WriteLine("\n=== F1 Lap Times Demo ===\n");

//         // Create a List of sector times (like an array in JavaScript)
//         List<SectorTime> sectorTimes = new List<SectorTime>
//         {
//             new SectorTime { DriverName = "Verstappen", Time = TimeSpan.FromSeconds(28.5) },
//             new SectorTime { DriverName = "Verstappen", Time = TimeSpan.FromSeconds(29.2) },
//             new SectorTime { DriverName = "Verstappen", Time = TimeSpan.FromSeconds(27.8) },
//             new SectorTime { DriverName = "Hamilton", Time = TimeSpan.FromSeconds(28.7) },
//             new SectorTime { DriverName = "Hamilton", Time = TimeSpan.FromSeconds(29.0) },
//             new SectorTime { DriverName = "Hamilton", Time = TimeSpan.FromSeconds(28.1) }
//         };

//         // Get fastest lap
//         LapResult fastestLap = GetFastestLap(sectorTimes);

//         Console.WriteLine($"Fastest Lap: {fastestLap.DriverName} - {fastestLap.LapTime.TotalSeconds:F3} seconds");
//     }

//     public static LapResult GetFastestLap(List<SectorTime> sectorTimes)
//     {
//         return sectorTimes
//             .GroupBy(st => st.DriverName)
//             .Select(g => new LapResult
//             {
//                 DriverName = g.Key,
//                 LapTime = TimeSpan.FromMilliseconds(
//                     g.Sum(st => st.Time.TotalMilliseconds))
//             })
//             .OrderBy(r => r.LapTime)
//             .First();
//     }
// }