using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Recursion_MG
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Vector2 starLoc = Vector2.Zero;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
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
            starLoc = Mouse.GetState().Position.ToVector2();

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

            RecursiveDrawLines(new Vector2(10, 10), 100, Color.Magenta);
            RecursiveDrawLines(new Vector2(10, 50), 200, Color.Magenta);
            RecursiveDrawLines(new Vector2(10, 100), 50, Color.Magenta);

            DrawStar(starLoc, 50, 12, Color.Green);

            ShapeBatch.End();

            base.Draw(gameTime);
        }

        private void RecursiveDrawLines(Vector2 startPoint, float startLen, Color color)
        {
            // Goal: Draw until length < 5

            // Base case -- startLen <5
            if(startLen < 5)
            {
                // do nothing. all done.
            }
            // Recursive case
            else
            {
                // draw something
                Vector2 nextPoint = ShapeBatch.Line(startPoint, startLen, 0, 3, Color.MediumVioletRed);
                nextPoint.X += 10;
                //float nextLen = startLen * 0.9f;

                // Recursive call with State Change
                RecursiveDrawLines(nextPoint, startLen * 0.9f, color);
            }
        }

        private void DrawStar(Vector2 center, float radius, int numSpokes, Color color)
        {
            float angleInc = MathHelper.TwoPi / numSpokes;
            for(float angle = 0; angle < MathHelper.TwoPi; angle += angleInc)
            {
                ShapeBatch.Line(center, radius, angle, 10, color);
            }
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
