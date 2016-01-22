using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        AudioEngine sound;
        private SoundEffect music;
        private Texture2D earth;
        private Texture2D background;
        private Texture2D shuttle;
        private float angle = 0;
        private float vel = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 33);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("stars");
            earth = Content.Load<Texture2D>("earth");
            shuttle = Content.Load<Texture2D>("Shuttle");
            font = Content.Load<SpriteFont>("NewSpriteFont");
            music = Content.Load<SoundEffect>("music");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))

                    Exit();

                // TODO: Add your update logic here
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    vel += 0.0001f;
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    vel -= 0.0001f;
                if (Keyboard.GetState().IsKeyDown(Keys.F))
                    graphics.ToggleFullScreen();
                if (Keyboard.GetState().IsKeyDown(Keys.M))
                    music.Play();
                angle += vel;
                base.Update(gameTime);
            }    
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);

            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.Draw(earth, new Vector2(400, 240), Color.White);

            Vector2 location = new Vector2(400, 240);
            Rectangle sourceRectangle = new Rectangle(0, 0, shuttle.Width, shuttle.Height);
            Vector2 origin = new Vector2(0, 0);
            //Vector2 origin = new Vector2(shuttle.Width / 2, shuttle.Height / 2);

            spriteBatch.Draw(shuttle, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, "Hello, I am a font", new Vector2(100, 100), Color.WhiteSmoke);
            spriteBatch.End();

            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        protected override void OnActivated(object sender, System.
                                            EventArgs args)
        {
            this.Window.Title = "Active Application";
            base.OnActivated(sender, args);
        }

        protected override void OnDeactivated(object sender, System.
                                              EventArgs args)
        {
            this.Window.Title = "InActive Application";
            base.OnActivated(sender, args);
        }
    }
}
