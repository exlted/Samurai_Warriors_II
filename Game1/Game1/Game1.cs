﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Storage;
using System.Collections.Generic;
using System;
using System.IO;
using BTEngine;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        AudioEngine sound;
        private float angle = 0;
        private float vel = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 33);
            Window.Title = "Samurai Warriors II";
            Window.AllowAltF4 = false;
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
            Assets.importFiles(this);
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
                    Assets.sounds["music"].Play();
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

            //spriteBatch.Draw(Assets.textures["stars"], new Rectangle(0, 0, 800, 480), Color.White);
            //spriteBatch.Draw(Assets.textures["earth"], new Vector2(400, 240), Color.White);

            //Vector2 location = new Vector2(400, 240);
            //Rectangle sourceRectangle = new Rectangle(0, 0, Assets.textures["shuttle"].Width, Assets.textures["shuttle"].Height);
            //Vector2 origin = new Vector2(0, 0);
            ////Vector2 origin = new Vector2(shuttle.Width / 2, shuttle.Height / 2);
            //spriteBatch.DrawString(Assets.font, "Hello, I am a font", new Vector2(100, 100), Color.WhiteSmoke);
            //spriteBatch.Draw(Assets.textures["shuttle"], location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
            Texture2D rect = new Texture2D(graphics.GraphicsDevice, 80, 30);
            Color[] data = new Color[80 * 30];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            rect.SetData(data);
            Vector2 coor = new Vector2(0, 0);
            spriteBatch.Draw(rect, coor, Color.White);

            spriteBatch.End();



            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        protected override void OnActivated(object sender, System.
                                            EventArgs args)
        {
            base.OnActivated(sender, args);
        }

        protected override void OnDeactivated(object sender, System.
                                              EventArgs args)
        {
            base.OnActivated(sender, args);
        }
    }
}
