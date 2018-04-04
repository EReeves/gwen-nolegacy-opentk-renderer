using System.Collections.Generic;
using Gwen.Renderer.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = System.Drawing.Rectangle;

namespace Gwen.Renderer
{
    /// <inheritdoc />
    /// <summary>
    /// Monogame renderer for GWEN
    /// </summary>
    public class Monogame : Base
    {
        private readonly SpriteBatch spriteBatch;
        private readonly ContentManager content;

        private readonly Texture2D pixelTexture;
        private Color drawColor;
        private System.Drawing.Color drawColorInternal;
        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();        

        /// <summary>
        /// Both a SpriteBatch and ContentManager are required.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="content"></param>
        public Monogame(SpriteBatch spriteBatch, ContentManager content)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;

            pixelTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        }

        /// <summary>
        /// Current color to draw.
        /// Automatically converts color to and from Monogame/System.Drawing Colours.
        /// </summary>
        public override System.Drawing.Color DrawColor
        {
            get => drawColorInternal;
            set
            {
                drawColorInternal = value;
                drawColor = drawColorInternal.ToXnaColor();
            }
        }

        private void UpdatePixelTextureColor()
        {
            var colourData = new[] {DrawColor.ToXnaColor()};
            pixelTexture.SetData(colourData);
        }

        /// <inheritdoc />
        public override void DrawFilledRect(Rectangle rect)
        {
            spriteBatch.Draw(pixelTexture,rect.ToXnaRectangle(), drawColor);
        }

        /// <inheritdoc />
        public override void DrawLine(int x, int y, int a, int b)
        {
            spriteBatch.DrawLine(x,y,a,b,drawColor);
        }

        /// <inheritdoc />
        public override void DrawPixel(int x, int y)
        {
            spriteBatch.Draw(pixelTexture,new Vector2(x,y), drawColor);
        }

        /// <inheritdoc />
        public override void LoadTexture(Texture t)
        {
            content.Load<Texture2D>(t.Name);
        }
    }
}