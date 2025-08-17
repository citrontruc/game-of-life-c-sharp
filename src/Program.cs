/* Main class of our program */

using Raylib_cs;

class Program
{
    // Display Information
    private static readonly int _screenHeight = 600;
    private static readonly int _screenWidth = 800;
    private static readonly int _targetFPS = 60;

    // Game Of Life Information
    private static readonly int _numColumns = 100;
    private static readonly int _numRows = 100;
    private static readonly int _cellSize = 5;
    private static readonly int _lifeProbability = 30;

    // Update Information
    private static double _updateTime = 0.1;
    enum Status {
        Pause,
        Edit,
        Run
    };
    private static Status _currentStatus = Status.Run;

    public static void Main()
    {
        Raylib.InitWindow(_screenWidth, _screenHeight, "Game of Life");

        (GameOfLifeRule gameOfLife, Timer updateTimer) = Initialize();
        while (!Raylib.WindowShouldClose())
        {
            Update(gameOfLife, updateTimer);
            Draw(gameOfLife);
        }
        Raylib.CloseWindow();
    }

    public static (GameOfLifeRule, Timer) Initialize()
    {
        Raylib.SetTargetFPS(_targetFPS);
        GameOfLifeRule gameOfLife = new(_numColumns, _numRows, _cellSize, _lifeProbability);
        Timer updateTimer = new(_updateTime);
        return (gameOfLife, updateTimer);
    }

    public static void Update(GameOfLifeRule gameOfLife, Timer updateTimer)
    {
        if (_currentStatus == Status.Run)
        {
            bool updateFrame = updateTimer.Increment();
            if (updateFrame)
            {
                gameOfLife.Update();
            }
        }
        
        // Get user input
        // Update GoL accordingly
    }

    public static void Draw(GameOfLifeRule gameOfLife)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        gameOfLife.Draw();
        // Mettre texte avec numItération
        // Mettre texte sur l'état
        // Dessiner GoL

        Raylib.EndDrawing();
    }
}




