using Gwen.Renderer.Renderer;
using Microsoft.Xna.Framework;

namespace Gwen.Renderer.Extensions
{
    public static class Conversions
    {
        public static Rectangle ToMongameRectangle(this System.Drawing.Rectangle rect)
        {
            return  new Rectangle(rect.X,rect.Y,rect.Width,rect.Height);
        }

        public static Color ToMonogameColor(this System.Drawing.Color colour)
        {
            return new Color(colour.R,colour.G,colour.B,colour.A);
        }
    }
}