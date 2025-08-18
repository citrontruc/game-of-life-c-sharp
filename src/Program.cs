/* Main class of our program */

using Raylib_cs;

class Program
{
    // Display Information
    private static readonly int _screenHeight = 600;
    private static readonly int _screenWidth = 800;
    private static readonly int _targetFPS = 60;

    // Game Of Life Information
    private static readonly int _numColumns = 50;
    private static readonly int _numRows = 50;
    private static readonly int _cellSize = 10;
    private static readonly int _lifeProbability = 30;

    private static readonly int _gridOffsetX = (int)(_screenWidth - _numColumns * _cellSize) / 2;
    private static readonly int _gridOffsetY = (int)(_screenHeight - _numRows * _cellSize) / 2;

    public static Game? gameOfLife;

    public static void Main()
    {
        Raylib.InitWindow(_screenWidth, _screenHeight, "Game of Life");

        gameOfLife = Initialize();
        while (!Raylib.WindowShouldClose())
        {
            Update(gameOfLife);
            Draw(gameOfLife);
        }
        Raylib.CloseWindow();
    }

    public static Game Initialize()
    {
        Raylib.SetTargetFPS(_targetFPS);
        Game gameOfLife = new(_numColumns, _numRows, _cellSize, _lifeProbability);
        return gameOfLife;
    }

    public static void Update(Game gameOfLife)
    {
        gameOfLife.Update();
        // Get user input
        // Update GoL accordingly
    }

    public static void Draw(Game gameOfLife)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        gameOfLife.Draw(_gridOffsetX, _gridOffsetY);
        DrawHud(gameOfLife);
        // Mettre texte sur l'état

        Raylib.EndDrawing();
    }

    public static void DrawHud(Game gameOfLife)
    {
        gameOfLife.DrawHud(_gridOffsetX, _gridOffsetY, _screenWidth, _screenHeight);
    }
}
