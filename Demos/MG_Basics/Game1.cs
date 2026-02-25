using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MG_Basics
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D pandaImg;
        private Rectangle pandaLoc;
        private const float pandaScale = 0.1f;
        private const int DesiredWidth = 1200;
        private const int DesiredHeight = 900;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = DesiredWidth;
            _graphics.PreferredBackBufferHeight = DesiredHeight;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            pandaImg = Content.Load<Texture2D>("panda");

            pandaLoc = new Rectangle(10, 10, 
                (int)(pandaImg.Width*pandaScale),
                (int)(pandaImg.Height*pandaScale));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            pandaLoc.X++;
            pandaLoc.Y++;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aquamarine);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            //_spriteBatch.Draw(pandaImg, new Vector2(10,10), Color.White);
            _spriteBatch.Draw(pandaImg, pandaLoc, Color.White);

            _spriteBatch.Draw(pandaImg, 
                new Rectangle(10, 10, DesiredWidth/8, DesiredHeight/8), 
                Color.Magenta);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
