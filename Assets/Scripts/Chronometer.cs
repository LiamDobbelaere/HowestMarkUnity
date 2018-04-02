using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Chronometer {
    private Stopwatch stopwatch;

    public Chronometer()
    {
        stopwatch = new Stopwatch();
    }

    public void Start()
    {
        stopwatch.Reset();
        stopwatch.Start();
    }

    public long Stop()
    {
        stopwatch.Stop();

        return stopwatch.ElapsedTicks * 1000000 / Stopwatch.Frequency;
    }
}
