using Microsoft.Extensions.Logging;
using Raylib_cs;

public class Grid : UI.IDrawable
{
    // Debug variables
    private readonly ILogger _logger = Logger.CreateLogger<Grid>();

    // Cell variables
    public int cellSize { get; private set; }
    public int columns { get; private set; }
    public int rows { get; private set; }
    private bool[,] cells;

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
            throw new IndexOutOfRangeException($@"Tried to update value at column and row {column}, {row} 
            But grid only has dimensions {columns}, {rows}.");
        }
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

    public void Draw()
    {

    }
}
