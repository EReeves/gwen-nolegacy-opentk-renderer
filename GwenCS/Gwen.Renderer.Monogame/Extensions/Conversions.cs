
using Microsoft.Xna.Framework;

namespace Gwen.Renderer.Extensions
{
    public static class Conversions
    {
       
        public static Rectangle ToXnaRectangle(this System.Drawing.Rectangle rect)
        {
            return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }
        
        public static System.Drawing.Rectangle ToGwenRectangle(this Rectangle rect)
        {
            return new System.Drawing.Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }

        public static Color ToXnaColor(this System.Drawing.Color colour)
        {
            return new Color(colour.R, colour.G, colour.B, colour.A);
        }

        public static System.Drawing.Color ToGwenColor(this Color colour)
        {
            return System.Drawing.Color.FromArgb(colour.R, colour.G, colour.B, colour.A);
        }
    }
}