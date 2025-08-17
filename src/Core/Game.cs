/* A class to launch a game. */

using Raylib_cs;

public class Game
{
    private GameOfLifeRule gameOfLife;

    public Game(int numColumns, int numRows, int cellSize, int LifeProbability)
    {
        gameOfLife = new(numColumns, numRows, cellSize, LifeProbability);
    }

    public void Update()
    {
        gameOfLife.Update();
    }

    public void Draw()
    {
        gameOfLife.Draw();
    }

}
