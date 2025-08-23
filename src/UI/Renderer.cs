/* An interface to draw the items on screen. */

namespace UI
{
    public interface IDrawable
    {
        void Draw(int offsetX, int offsetY);
    }
}