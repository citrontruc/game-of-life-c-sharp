using System.Numerics;
using Raylib_cs;

public class Player
{
    private readonly PlayerController _playerController = new();
    private Vector2 _playerPosition = new(0, 0);
    private readonly int _playerSize;
    private static readonly double _timeLimitFlash = 0.3;
    private Timer _playerFlashTimer = new(_timeLimitFlash);
    private bool _visible = false;

    public Player(int playerSize) {
        _playerSize = playerSize;
    }

    public void Update(int columns, int rows, int cellSize)
    {
        (int moveX, int moveY) = _playerController.GetUserAction();
        _playerPosition.X = Math.Clamp(_playerPosition.X + moveX, 0, columns);
        _playerPosition.Y = Math.Clamp(_playerPosition.Y + moveY, 0, rows);
    }

    public void Draw(int offsetX, int offsetY)
    {
        if (_visible)
        {
            Raylib.DrawRectangle((int)_playerPosition.X * _playerSize + offsetX, (int)_playerPosition.Y * _playerSize + offsetY, _playerSize, _playerSize, Color.Blue);
        }
        bool flash = _playerFlashTimer.Increment();
        _visible = flash ? !_visible : _visible;
    }
}
