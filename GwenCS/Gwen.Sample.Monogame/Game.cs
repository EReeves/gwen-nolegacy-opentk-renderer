using Gwen.Control;
using Gwen.Renderer.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Color = Microsoft.Xna.Framework.Color;

namespace Gwen.Sample.Monogame
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        //Gwen
        private Gwen.Renderer.Monogame renderer;
        private Gwen.Skin.Base skin;
        private Gwen.Control.Canvas canvas;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";        
        }

        protected override void Initialize()
        {
            base.Initialize();
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            renderer = new Gwen.Renderer.Monogame(spriteBatch, Content);
            skin = new Gwen.Skin.TexturedBase(renderer, "DefaultSkin");
            
            canvas = new Canvas(skin);
            canvas.SetSize(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            canvas.ShouldDrawBackground = true;
            canvas.BackgroundColor = Color.Blue.ToGwenColor();
            
        }   

        protected override void UnloadContent()
        {
            canvas.Dispose();
            skin.Dispose();
            renderer.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == 
                ButtonState.Pressed || Keyboard.GetState().IsKeyDown(
                    Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();
            
            canvas.RenderCanvas();
            
            spriteBatch.End();
            
            
            base.Draw(gameTime);
        }
    }
}