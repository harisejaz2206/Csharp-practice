// Question 3: Qualifying Analysis
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
        // 2. Calculate gap to pole position (fastest valid lap in Q3)
        // 3. Find drivers who improved their times in each session
        // 4. Group drivers by their best session performance
    }
}