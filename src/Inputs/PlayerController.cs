/* An object to interpret user inputs */

using System.Numerics;

public class PlayerController
{
    private readonly InputHandler _inputHandler = new();
    private bool _isMovingHold = false;
    private static readonly double _timeLimitInput = 0.1;
    private Timer _movementHoldTimer = new(_timeLimitInput);

    private (int, int) InterpretUserInput(UserInput userInput)
    {
        // Check if the user is holding a key.
        bool holdMode;
        int moveX;
        int moveY;
        if (userInput.UpHold || userInput.DownHold || userInput.LeftHold || userInput.RightHold)
        {
            holdMode = _movementHoldTimer.Increment();
            if (holdMode)
            {
                _isMovingHold = true;
            }
        }
        if (_isMovingHold)
        {
            moveX = (userInput.RightHold ? 1 : 0) - (userInput.LeftHold ? 1 : 0);
            moveY = (userInput.DownHold ? 1 : 0) - (userInput.UpHold ? 1 : 0);
        }
        else
        {
            moveX = (userInput.RightRelease ? 1 : 0) - (userInput.LeftRelease ? 1 : 0);
            moveY = (userInput.DownRelease ? 1 : 0) - (userInput.UpRelease ? 1 : 0);
        }
        _isMovingHold = false;
        return (moveX, moveY);
    }

    public (int, int, bool, bool) GetUserAction()
    {
        UserInput userInput = _inputHandler.GetUserInput();
        (int moveX, int moveY) = InterpretUserInput(userInput);
        return (moveX, moveY, userInput.Input, userInput.Pause);
    }
}
