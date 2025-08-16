// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Logging;

Console.WriteLine("Hello, World!");
int screenHeight = 1080;
int screenWidth = 1920;
int numColumns = 100;
int numRows = 100;
int cellSize = 5;
int LifeProbability = 30;
GameOfLifeRule gameOfLife = new(numColumns, numRows, cellSize, LifeProbability);
