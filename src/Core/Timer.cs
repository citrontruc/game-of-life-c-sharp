/* A timer to associate to an action as if a cooldown. */

using Raylib_cs;

public class Timer
{
    public double Time = 0;
    private double _timeMin = 0.1;
    private double _timeMax = 1.0;
    private double _timeLimit;

    public Timer(double timeLimit)
    {
        setTimeLimit(timeLimit);
    }

    public void setTimeLimit(double timeLimit)
    {
        this._timeLimit = Math.Clamp(timeLimit, _timeMin, _timeMax);
    }

    public bool Increment()
    {
        Time += Raylib.GetFrameTime();
        if (Time >= _timeLimit)
        {
            Reset();
            return true;
        }
        return false;
    }

    public void Reset()
    {
        Time = 0;
    }

}
