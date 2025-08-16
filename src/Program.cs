// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Logging;
using Raylib_cs;

Console.WriteLine("Hello, World!");
int screenHeight = 600;
int screenWidth = 800;
int TargetFPS = 5;
int numColumns = 100;
int numRows = 100;
int cellSize = 5;
int LifeProbability = 50;
GameOfLifeRule gameOfLife = new(numColumns, numRows, cellSize, LifeProbability);


Raylib.InitWindow(screenWidth, screenHeight, "Hello World");
Raylib.SetTargetFPS(TargetFPS);

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
    gameOfLife.Update();
    gameOfLife.Draw();
    Raylib.EndDrawing();
}

Raylib.CloseWindow();