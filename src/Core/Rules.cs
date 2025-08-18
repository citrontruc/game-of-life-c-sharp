/* Ruless to update our grid for the game of life */

using Microsoft.Extensions.Logging;
using Raylib_cs;
using System.Numerics;
using UI;

public class GameOfLifeRule : IDrawable
{
    private readonly ILogger _logger = Logger.CreateLogger<GameOfLifeRule>();

    private Grid _gameOfLifeGrid;
    private static readonly int _randomSeed = 42;
    private Random _randomGenerator = new(_randomSeed);

    // items to draw the game
    private Color _gameColor = Color.White;
    private EntityDrawer _entityDrawer = new();

    public GameOfLifeRule(int columns, int rows, int cellSize, int probability)
    {
        _logger.LogInformation("Initializing GameOfLife");
        _gameOfLifeGrid = new Grid(columns, rows, cellSize);
        Initialize(probability);
        _logger.LogInformation("Initialized GameOfLife");
    }

    public (int, int, int) GetGridDimension()
    {
        return (_gameOfLifeGrid.Columns, _gameOfLifeGrid.Rows, _gameOfLifeGrid.CellSize);
    }

    public void Initialize(int probability)
    {
        // Grid is initialized at random.
        for (int interRows = 0; interRows < _gameOfLifeGrid.Rows; interRows++)
        {
            for (int interColumns = 0; interColumns < _gameOfLifeGrid.Columns; interColumns++)
            {
                _gameOfLifeGrid.SetCell(interRows, interColumns, _randomGenerator.Next(101) < probability);
            }
        }
    }

    public void Update()
    {
        _logger.LogInformation("Updating game of life.");
        int interCount;
        bool interGridCellValue;
        bool[,] nextCells = (bool[,])_gameOfLifeGrid.Cells.Clone();
        // In the game of life, we "resurrect" squares with three neighbors and "kill" cells with less than two neighbors or more than 3.
        // We do operations on a clone of our grid in order to avoid modifications breaking our grid. 
        for (int interRows = 0; interRows < _gameOfLifeGrid.Rows; interRows++)
        {
            for (int interColumns = 0; interColumns < _gameOfLifeGrid.Columns; interColumns++)
            {
                interCount = _gameOfLifeGrid.MooreNeighborhoodCount(interRows, interColumns);
                interGridCellValue = _gameOfLifeGrid.GetCell(interRows, interColumns);
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
        _gameOfLifeGrid.UpdateGrid(nextCells);
        _logger.LogInformation("Game of life updated.");
    }

    public void Draw(int offsetX, int offsetY)
    {
        // To be displaced in a renderer maybe.
        bool interCell;
        Vector2 cellPosition;
        for (int interRows = 0; interRows < _gameOfLifeGrid.Rows; interRows++)
        {
            for (int interColumns = 0; interColumns < _gameOfLifeGrid.Columns; interColumns++)
            {
                interCell = _gameOfLifeGrid.GetCell(interRows, interColumns);
                if (interCell)
                {
                    cellPosition = _gameOfLifeGrid.ToWorld(interRows, interColumns);
                    _entityDrawer.DrawRectangle((int)cellPosition.X + offsetX, (int)cellPosition.Y + offsetY, _gameOfLifeGrid.CellSize, _gameOfLifeGrid.CellSize, _gameColor);
                }
            }
        }
    }
}
