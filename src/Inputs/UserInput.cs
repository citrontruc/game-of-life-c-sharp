/* A class to store user inputs */

using System.Numerics;

public class UserInput
{
    // Mouse
    public Vector2 MousePosition { get; set; }
    public bool LeftClick { get; set; }
    public bool RightClick { get; set; }

    // Movement
    public bool UpHold { get; set; }
    public bool DownHold { get; set; }
    public bool LeftHold { get; set; }
    public bool RightHold { get; set; }

    public bool UpRelease { get; set; }
    public bool DownRelease { get; set; }
    public bool LeftRelease { get; set; }
    public bool RightRelease { get; set; }

    // Other
    public bool Input { get; set; }
    public bool Pause { get; set; }
}
