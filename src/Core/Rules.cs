using Microsoft.Extensions.Logging;

class GameOfLifeRule
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
        
    }
}