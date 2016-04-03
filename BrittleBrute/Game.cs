using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BrittleBrute
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Character player1 = new Character(200, 200, 120, 120);

        private Texture2D playerWalk;
        private Texture2D playerWalkBackwards;

        private SpriteFont header;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Load all Textures to be used
            playerWalk = Content.Load<Texture2D>("playerWalk");
            playerWalkBackwards = Content.Load<Texture2D>("playerWalkBackwards");
            // Load Textures into characters
            player1.setTexture(playerWalk, 6);
            // Set Character Positions
            player1.setPosition(player1.getX(), player1.getY());
            // Load fonts
            header = Content.Load<SpriteFont>("header");
        }

        protected override void UnloadContent()
        {
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Set up keyboard
            KeyboardState state = Keyboard.GetState();
            //Calculate the current framerate
            float frameRate = (1 / (float)gameTime.ElapsedGameTime.TotalSeconds);

            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A) && player1.getX() > 0)
            {
                if (!(player1.getTexture() == playerWalkBackwards))
                {
                    player1.setTexture(playerWalkBackwards, 6);
                }

                player1.moveLeft(4);
            }

            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D) && player1.getX() + player1.getWidth() < GraphicsDevice.Viewport.Width)
            {
                if (!(player1.getTexture() == playerWalk))
                {
                    player1.setTexture(playerWalk, 6);
                }
                player1.moveRight(4);
            }

            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W) && player1.getY() - 50 > 0)
            {
                player1.moveUp(4);
            }

            if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S) && player1.getY() + player1.getHeight() < GraphicsDevice.Viewport.Height)
            {
                player1.moveDown(4);
            }

            player1.updateFrame();
            player1.setPosition(player1.getX(), player1.getY());
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            // Begin the drawing
            spriteBatch.Begin();
            // Draw everything to screen
            spriteBatch.Draw(player1.getTexture(), player1.getPosition(), player1.getSource(), Color.White);

            spriteBatch.DrawString(header, "SAM", new Vector2((player1.getX() + 50), (player1.getY() - 25)), Color.Black);
            // End the drawing
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
