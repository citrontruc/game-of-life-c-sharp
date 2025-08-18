/* A class to launch a game. */

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

    public void Update()
    {
        (int columns, int rows, int cellSize) = _gameOfLife.GetGridDimension();
        _player.Update(columns, rows, cellSize);
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
