﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LD32_OSTGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState PreviousKeyboard;
        MouseState PreviousMouse;
        GamePadState PreviousGamePad;
        DateTime LimitedUpdateTime;
        int limitDelay = 50;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            LimitedUpdateTime = DateTime.Now;

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
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            #region Keyboard
            KeyboardState currentKeyboard = Keyboard.GetState();

            if(currentKeyboard.IsKeyDown(Keys.W))
            {

            }

            if(currentKeyboard.IsKeyDown(Keys.A))
            {

            }

            if(currentKeyboard.IsKeyDown(Keys.D))
            {

            }

            if(currentKeyboard.IsKeyDown(Keys.S))
            {

            }

            if(currentKeyboard.IsKeyDown(Keys.Q))
            {

            }

            if(currentKeyboard.IsKeyDown(Keys.E))
            {

            }

            if(currentKeyboard.IsKeyDown(Keys.Space))
            {

            }

            PreviousKeyboard = currentKeyboard;
            #endregion

            #region Gamepad
            GamePadState currentPad = GamePad.GetState(PlayerIndex.One);

            if(currentPad.DPad.Up == ButtonState.Pressed)
            {

            }

            if (currentPad.DPad.Down == ButtonState.Pressed)
            {

            }

            if(currentPad.DPad.Left == ButtonState.Pressed)
            {

            }

            if(currentPad.DPad.Right == ButtonState.Pressed)
            {

            }

            if(currentPad.Buttons.A == ButtonState.Pressed)
            {

            }

            if(currentPad.Buttons.X == ButtonState.Pressed)
            {

            }

            if(currentPad.Buttons.Y == ButtonState.Pressed)
            {

            }

            PreviousGamePad = currentPad;
            #endregion



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Pink);

            //var screenCenter = new Vector2(GraphicsDevice.Viewport.Bounds.Width / 2, GraphicsDevice.Viewport.Bounds.Height / 2);
            //var textureCenter = new Vector2(Texture2D.Width / 2, Texture2D.Height / 2);
            //            SpriteBatch.Draw(Texture2D, screenCenter, null, Color.White, 0f, textureCenter, 1f, SpriteEffects.None, 1f);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
