using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace PE_MG_Buttons
{
    public class Game1 : Game
    {
        // Fields created by the MG template
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // The list of buttons and setup for random bg color
        private SpriteFont font;
        private List<Button> buttons = new List<Button>();
        private Color bgColor = Color.White;
        private Random rng = new Random();

        private Button magicButton;

        private Texture2D duckyImg;
        private Vector2 duckyLoc;



        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // TODO: ADD Your new fields here!
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

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
            font = Content.Load<SpriteFont>("buttonFont");

            // Create a few 100x200 buttons down the left side
            buttons.Add(new Button(
                    _graphics.GraphicsDevice,
                    new Rectangle(10, 40, 200, 100),
                    "Random Color",
                    font,
                    Color.LightBlue));
            buttons[0].OnButtonClick += this.RandomizeBackground;
            buttons[0].OnButtonClick += this.ToggleButton;

            duckyImg = Content.Load<Texture2D>("ducky");

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Add your additional button setup code here!
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        }

        protected override void UnloadContent()
        {
            buttons[0].OnButtonClick -= this.RandomizeBackground;
            base.UnloadContent();
        }

        // There is no need to add anything to Game1's Update method!
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Button b in buttons)
            {
                b.Update(gameTime);
            }

            //duckyLoc = Mouse.GetState().Position.ToVector2();
            MoveDuck();
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            _spriteBatch.Begin();

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Add your additional drawing code here!
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            _spriteBatch.Draw(duckyImg, duckyLoc, Color.Goldenrod);

            // Draw the buttons last.
            foreach (Button b in buttons)
            {
                b.Draw(_spriteBatch);
            }

            if (magicButton != null)
            {
                magicButton.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public Vector2 DuckyLoc
        {
            get
            {
                return duckyLoc;
            }
            set
            {
                duckyLoc = value;
            }
        }

        public Vector2 getLoc()
        {
            return duckyLoc;
        }

        private void MoveDuck()
        {
            // sets the field
            //duckyLoc = Mouse.GetState().Position.ToVector2();

            // sets WHOLE VALUE via property
            DuckyLoc = Mouse.GetState().Position.ToVector2();

            // sets in pieces
            //getLoc().X = Mouse.GetState().Position.ToVector2().X;
            //DuckyLoc.Y = Mouse.GetState().Position.ToVector2().Y;
        }

        // #################################################################################
        // Button click handlers!
        // #################################################################################

        /// <summary>
        /// LEAVE THIS ONE ALONE
        /// Randomizes the saved background color
        /// </summary>
        public void RandomizeBackground()
        {
            bgColor = new Color(rng.Next(0, 200), rng.Next(0, 200), rng.Next(0, 200));
        }

        public void ToggleButton()
        {
            if (magicButton == null)
            {
                magicButton = new Button(
                        _graphics.GraphicsDevice,
                        new Rectangle(10, 300, 200, 100),
                        "HI!!!!!",
                        font,
                        Color.Magenta);
            }
            else
            {
                magicButton = null;
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // TODO: Add your new button click handlers here!
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    }
}
