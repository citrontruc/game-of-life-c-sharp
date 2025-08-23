/* A class to handle the creation and updates of Conway's game of life. */

using System.Numerics;
using Raylib_cs;
using UI;

public class Game : IDrawable
{
    private Player _player;
    private GameOfLifeRule _gameOfLife;

    // Update Information
    private static double _updateTime = 0.1;
    private Timer _updateTimer = new(_updateTime);
    private static int _numIteration = 1;
    enum Status
    {
        Edit,
        Run
    };

    private static Status _currentStatus = Status.Run;

    public Game(int numColumns, int numRows, int cellSize, int LifeProbability)
    {
        _player = new(cellSize);
        _gameOfLife = new(numColumns, numRows, cellSize, LifeProbability);
    }

    public void Update(int offsetX, int offsetY)
    {
        (int columns, int rows, int cellSize) = _gameOfLife.GetGridDimension();
        (bool input, bool pause, Vector2 mousePosition, bool leftClick) = _player.Update(columns, rows, cellSize);
        _currentStatus = pause ? Status.Edit : Status.Run;
        switch (_currentStatus)
        {
            case Status.Run:
                bool updateFrame = _updateTimer.Increment();
                if (updateFrame)
                {
                    _gameOfLife.Update();
                }
                _numIteration++;
                break;
            case Status.Edit:
                if (input)
                {
                    Vector2 playerPosition = _player.GetPlayerPosition();
                    _gameOfLife.InvertCell((int)playerPosition.X, (int)playerPosition.Y);
                }
                if (leftClick)
                    {
                        float mouseXNoOffset = mousePosition.X - offsetX;
                        float mouseYNoOffset = mousePosition.Y - offsetY;
                        Vector2 mousePositionCorrected = new(mouseXNoOffset, mouseYNoOffset);
                        if (_gameOfLife.CheckIfInGrid(mousePositionCorrected))
                        {
                            _gameOfLife.InvertCell(mousePositionCorrected);
                        }
                }

                break;
        }
    }

    public void Draw(int offsetX, int offsetY)
    {
        _gameOfLife.Draw(offsetX, offsetY);
        _player.Draw(offsetX, offsetY);
    }

    public void DrawHud(int offsetX, int offsetY, int screenWitdth, int screenHeight)
    {
        int fontSize = 20;
        string textIteration = "Number of iterations: ";
        string numIteration = $"{_numIteration}";
        int textWidth = Raylib.MeasureText(numIteration, fontSize);
        Raylib.DrawText(textIteration, offsetX, offsetY - fontSize, fontSize, Color.Red);
        Raylib.DrawText(numIteration, screenWitdth - offsetX - textWidth, offsetY - fontSize, fontSize, Color.Red);
        switch (_currentStatus)
        {
            case Status.Run:
                break;
            case Status.Edit:
                break;
        }
    }

}
