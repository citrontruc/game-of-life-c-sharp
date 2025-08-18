/* An object to interpret user inputs */

using System.Numerics;

public class PlayerController
{
    private readonly InputHandler _inputHandler = new();
    private Vector2 _playerPosition = new(0, 0);
    private static readonly double _timeLimitInput = 0.3;
    private Timer _movementHoldTimer = new(_timeLimitInput);
    private bool _isMovingHold = false;

    private void InterpretUserInput(UserInput userInput)
    {
        return;
    }

    public void GetUserAction()
    {
        UserInput userInput = _inputHandler.GetUserInput();
        InterpretUserInput(userInput);
        return;
    }
}
