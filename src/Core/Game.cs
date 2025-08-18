/* A class to launch a game. */

using Raylib_cs;
using UI;

public class Game : IDrawable
{
    private GameOfLifeRule _gameOfLife;

    public Game(int numColumns, int numRows, int cellSize, int LifeProbability)
    {
        _gameOfLife = new(numColumns, numRows, cellSize, LifeProbability);
    }

    public void Update()
    {
        _gameOfLife.Update();
    }

    public void Draw(int offsetX, int offsetY, Color color)
    {
        _gameOfLife.Draw(offsetX, offsetY, color);
    }

}
