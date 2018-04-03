using Gwen.Renderer.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = System.Drawing.Rectangle;

namespace Gwen.Renderer.Renderer
{
    public class Monogame : Base
    {
        private readonly SpriteBatch spriteBatch;
        private readonly ContentManager content;

        private Texture2D pixelTexture;
        private Color drawColor;
        private System.Drawing.Color drawColorInternal;
        

        public Monogame(SpriteBatch spriteBatch, ContentManager content)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;

            pixelTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        }

        public override System.Drawing.Color DrawColor
        {
            get => drawColorInternal;
            set
            {
                drawColorInternal = value;
                drawColor = drawColorInternal.ToMonogameColor();
            }
        }

        private void UpdatePixelTextureColor()
        {
            var colourData = new[] {DrawColor.ToMonogameColor()};
            pixelTexture.SetData(colourData);
        }

        public override void DrawFilledRect(Rectangle rect)
        {
            spriteBatch.Draw(pixelTexture,rect.ToMongameRectangle(), drawColor);
        }

        public override void DrawLine(int x, int y, int a, int b)
        {
            spriteBatch.DrawLine(x,y,a,b,drawColor);
        }

        public override void DrawPixel(int x, int y)
        {
            spriteBatch.Draw(pixelTexture,new Vector2(x,y), drawColor);
        }

    }
}