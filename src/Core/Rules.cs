/* Ruless to update our grid for the game of life */

using Microsoft.Extensions.Logging;
using Raylib_cs;
using System.Numerics;
using UI;

public class GameOfLifeRule : IDrawable
{
    private readonly ILogger _logger = Logger.CreateLogger<GameOfLifeRule>();

    private Grid gameOfLifeGrid;
    private static readonly int randomSeed = 42;
    private Random randomGenerator = new(randomSeed);

    public GameOfLifeRule(int columns, int rows, int cellSize, int probability)
    {
        _logger.LogInformation("Initializing GameOfLife");
        gameOfLifeGrid = new Grid(columns, rows, cellSize);
        Initialize(probability);
        _logger.LogInformation("Initialized GameOfLife");
    }

    public void Initialize(int probability)
    {
        for (int interRows = 0; interRows < gameOfLifeGrid.rows; interRows++)
        {
            for (int interColumns = 0; interColumns < gameOfLifeGrid.columns; interColumns++)
            {
                gameOfLifeGrid.SetCell(interRows, interColumns, randomGenerator.Next(101) < probability);
            }
        }
    }

    public void Update()
    {
        _logger.LogInformation("Updating game of life.");
        int interCount;
        bool interGridCellValue;
        bool[,] nextCells = (bool[,])gameOfLifeGrid.cells.Clone();
        // In the game of life, we "resurrect" squares with three neighbors and "kill" cells with less than two neighbors or more than 3.
        // We do operations on a clone of our grid in order to avoid modifications breaking our grid. 
        for (int interRows = 0; interRows < gameOfLifeGrid.rows; interRows++)
        {
            for (int interColumns = 0; interColumns < gameOfLifeGrid.columns; interColumns++)
            {
                interCount = gameOfLifeGrid.MooreNeighborhoodCount(interRows, interColumns);
                interGridCellValue = gameOfLifeGrid.GetCell(interRows, interColumns);
                if (interGridCellValue)
                {
                    if (interCount < 2 || interCount > 3)
                    {
                        nextCells[interRows, interColumns] = false;
                    }
                }
                else
                {
                    if (interCount == 3)
                    {
                        nextCells[interRows, interColumns] = true;
                    }
                }
            }
        }
        gameOfLifeGrid.UpdateGrid(nextCells);
        _logger.LogInformation("Game of life updated.");
    }

    public void Draw()
    {
        // To be displaced in a renderer maybe.
        bool interCell;
        Vector2 cellPosition;
        for (int interRows = 0; interRows < gameOfLifeGrid.rows; interRows++)
        {
            for (int interColumns = 0; interColumns < gameOfLifeGrid.columns; interColumns++)
            {
                interCell = gameOfLifeGrid.GetCell(interRows, interColumns);
                if (interCell)
                {
                    cellPosition = gameOfLifeGrid.ToWorld(interRows, interColumns);
                    Raylib.DrawRectangle((int)cellPosition.X, (int)cellPosition.Y, gameOfLifeGrid.cellSize, gameOfLifeGrid.cellSize, Color.White);
                }
            }
        }
    }
}
