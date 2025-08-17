/* A class to launch a game. */

using Raylib_cs;

public class Game
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

    public void Draw()
    {
        _gameOfLife.Draw();
    }

}
