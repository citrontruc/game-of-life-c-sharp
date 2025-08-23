/* Player entity */

using System.Numerics;
using Raylib_cs;
using UI;

public class Player : IDrawable
{
    // Control player
    private readonly PlayerController _playerController = new();
    private Vector2 _playerPosition = new(0, 0);
    private readonly int _playerSize;
    public bool Pause = false;

    // Draw player
    private readonly EntityDrawer _entityDrawer = new();
    private readonly Color _playerColor = Color.Blue;
    private static readonly double _timeLimitFlash = 0.3;
    private Timer _playerFlashTimer = new(_timeLimitFlash);
    private bool _visible = false;

    public Player(int playerSize)
    {
        _playerSize = playerSize;
    }

    public Vector2 GetPlayerPosition()
    {
        return _playerPosition;
    }

    public (bool, bool, Vector2, bool) Update(int columns, int rows, int cellSize)
    {
        (int moveX, int moveY, bool input, bool pause, Vector2 mousePosition, bool leftClick) = _playerController.GetUserAction();
        _playerPosition.X = Math.Clamp(_playerPosition.X + moveX, 0, columns);
        _playerPosition.Y = Math.Clamp(_playerPosition.Y + moveY, 0, rows);
        Pause = pause ? !Pause : Pause;
        return (input, Pause, mousePosition, leftClick);
    }

    public void Draw(int offsetX, int offsetY)
    {
        if (_visible)
        {
            _entityDrawer.DrawRectangle((int)_playerPosition.X * _playerSize + offsetX, (int)_playerPosition.Y * _playerSize + offsetY, _playerSize, _playerSize, _playerColor);
        }
        bool flash = _playerFlashTimer.Increment();
        _visible = flash ? !_visible : _visible;
    }
}
