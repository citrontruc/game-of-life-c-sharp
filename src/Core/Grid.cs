using Microsoft.Extensions.Logging;
using System.Numerics;

public class Grid
{
    // Debug variables
    private readonly ILogger _logger = Logger.CreateLogger<Grid>();

    // Cell variables
    public int cellSize { get; }
    public int columns { get; }
    public int rows { get; }
    public bool[,] cells { get; private set; }

    public Grid(int columns, int rows, int cellSize)
    {
        this.cellSize = cellSize;
        this.columns = columns;
        this.rows = rows;
        this.cells = new bool[columns, rows];
        _logger.LogInformation($"Created a grid of dimensions {columns} * {rows} with cellSize {cellSize}.");
    }

    private bool CheckColumnRowValidity(int column, int row)
    {
        if (column < 0) return false;
        if (row < 0) return false;
        if (column >= columns) return false;
        if (row >= rows) return false;
        return true;
    }

    public bool GetCell(int column, int row)
    {
        bool validInput = CheckColumnRowValidity(column, row);
        if (!validInput)
        {
            return false;
        }

        return cells[column, row];
    }

    public void SetCell(int column, int row, bool value)
    {
        if (CheckColumnRowValidity(column, row))
        {
            cells[column, row] = value;
        }
        else
        {
            _logger.LogInformation($@"Tried to update value at column and row {column}, {row} 
            But grid only has dimensions {columns}, {rows}.");
            throw new IndexOutOfRangeException($@"Tried to update value at column and row {column}, {row} 
            But grid only has dimensions {columns}, {rows}.");
        }
    }

    public Vector2 ToWorld(int column, int row)
    {
        bool validInput = CheckColumnRowValidity(column, row);
        if (!validInput)
        {
            throw new ArgumentException("Invalid input.");
        }
        Vector2 answerVector = new();
        answerVector.X = column * cellSize;
        answerVector.Y = row * cellSize;
        return answerVector;
    }
    public (int, int) ToGrid(Vector2 position)
    {
        int column = (int)(position.X / cellSize);
        int row = (int)(position.Y / cellSize);
        return (column, row);
    }

    public bool[] MooreNeighborhood(int column, int row)
    {
        var answerList = new bool[8];
        int[] neighborOffsetX = { -1, 0, 1, -1, 1, -1, 0, 1 };
        int[] neighborOffsetY = { -1, -1, -1, 0, 0, 1, 1, 1 };
        for (int i = 0; i < neighborOffsetX.Length; i++)
        {
            if (CheckColumnRowValidity(column + neighborOffsetX[i], row + neighborOffsetY[i]))
            {
                answerList[i] = cells[column + neighborOffsetX[i], row + neighborOffsetY[i]];
            }
            else
            {
                // By default all cells outside of our grid are false.
                answerList[i] = false;
            }
        }
        return answerList;
    }

    public int MooreNeighborhoodCount(int column, int row)
    {
        int count = 0;
        var answerList = MooreNeighborhood(column, row);
        for (int i = 0; i < answerList.Length; i++)
        {
            if (answerList[i])
            {
                count++;
            }
        }
        return count;
    }

    public void UpdateGrid(bool[,] nextCells)
    {
        _logger.LogInformation("Grid updated.");
        cells = nextCells;
    }
}
