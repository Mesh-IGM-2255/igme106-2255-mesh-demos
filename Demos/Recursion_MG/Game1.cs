using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Recursion_MG
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            // sprite batch and shape batch can NOT be open at the same time
            _spriteBatch.Begin();
            _spriteBatch.End();

            ShapeBatch.Begin(GraphicsDevice);

            DrawLines(new Vector2(10, 10), 100, Color.Magenta);
            DrawLines(new Vector2(10, 50), 200, Color.Magenta);
            DrawLines(new Vector2(10, 100), 50, Color.Magenta);

            ShapeBatch.End();

            base.Draw(gameTime);
        }

        private void RecursiveDrawLines(Vector2 startPoint, float startLen, Color color)
        {
            // Draw until length < 5
        }


        private void DrawLines(Vector2 startPoint, float startLen, Color color)
        {
            Vector2 start = startPoint;
            float length = startLen;
            Vector2 endPoint = ShapeBatch.Line(start, length, 0, 3, Color.MediumVioletRed);

            start = endPoint;
            start.X += 10;
            length *= 0.9f;
            endPoint = ShapeBatch.Line(start, length, 0, 3, Color.Purple);

            start = endPoint;
            start.X += 10;
            length *= 0.9f;
            endPoint = ShapeBatch.Line(start, length, 0, 3, Color.Purple);

            start = endPoint;
            start.X += 10;
            length *= 0.9f;
            endPoint = ShapeBatch.Line(start, length, 0, 3, Color.Purple);
        }
    }
}
