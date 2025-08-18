/* A class to launch a game. */

using Raylib_cs;
using UI;

public class Game : IDrawable
{
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
    private GameOfLifeRule _gameOfLife;

    public Game(int numColumns, int numRows, int cellSize, int LifeProbability)
    {
        _gameOfLife = new(numColumns, numRows, cellSize, LifeProbability);
    }

    public void Update()
    {
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
        }
    }

    public void Draw(int offsetX, int offsetY, Color color)
    {
        _gameOfLife.Draw(offsetX, offsetY, color);
    }

    public void DrawHud(int offsetX, int offsetY, int screeWitdth, int screenHeight)
    {
        int fontSize = 20;
        string textIteration = "Number of iterations: ";
        string numIteration = $"{_numIteration}";
        int textWidth = Raylib.MeasureText(numIteration, fontSize);
        switch (_currentStatus)
        {
            case Status.Run:
                Raylib.DrawText(textIteration, offsetX, offsetY - fontSize, fontSize, Color.Red);
                Raylib.DrawText(numIteration, screeWitdth - offsetX - textWidth, offsetY - fontSize, fontSize, Color.Red);
                break;
        }
    }

}
