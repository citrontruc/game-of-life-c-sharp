/* A timer to associate to an action */

using Raylib_cs;

public class Timer
{
    public double time = 0;
    private double timeMin = 0.1;
    private double timeMax = 1.0;
    private double timeLimit;

    public Timer(double timeLimit)
    {
        setTimeLimit(timeLimit);
    }

    public void setTimeLimit(double timeLimit)
    {
        this.timeLimit = Math.Clamp(timeLimit, timeMin, timeMax);
    }

    public bool Increment()
    {
        time += Raylib.GetFrameTime();
        if (time >= timeLimit)
        {
            Reset();
            return true;
        }
        return false;
    }

    public void Reset()
    {
        time = 0;
    }

}
