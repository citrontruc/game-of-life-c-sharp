/* A class to draw our entities on screen
As of now, it only draws Squares.*/

using Raylib_cs;

public class EntityDrawer
{
    // Create a method to draw an image.
    // Create a constructor to store an image.

    public void DrawRectangle(int positionX, int positionY, int sizeX, int sizeY, Color color)
    {
        Raylib.DrawRectangle(positionX, positionY, sizeX, sizeY, color);
    }
    public void DrawImage(int positionX, int positionY)
    {

    }
}
