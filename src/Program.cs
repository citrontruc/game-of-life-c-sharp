/* Main class of our program */

using Raylib_cs;

class Program
{
    // Display Information
    static int screenHeight = 600;
    static int screenWidth = 800;
    static int TargetFPS = 60;

    // Game Of Life Information
    static int numColumns = 100;
    static int numRows = 100;
    static int cellSize = 5;
    static int LifeProbability = 30;
    static double UpdateTime = 0.1;

    public static void Main()
    {
        Raylib.InitWindow(screenWidth, screenHeight, "Game of Life");
        
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
        Raylib.SetTargetFPS(TargetFPS);
        GameOfLifeRule gameOfLife = new(numColumns, numRows, cellSize, LifeProbability);
        Timer updateTimer = new(UpdateTime);
        return (gameOfLife, updateTimer);
    }

    public static void Update(GameOfLifeRule gameOfLife, Timer updateTimer)
    {
        bool updateFrame = updateTimer.Increment();
        if (updateFrame)
        {
            gameOfLife.Update();
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




