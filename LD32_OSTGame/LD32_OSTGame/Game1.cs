using System.Collections.Generic;
using Microsoft.Xna.Framework;
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

        List<Entity> Entites = new List<Entity>();        
        private Texture2D planeImg;
        private Plane plane;        
        
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

            planeImg = Content.Load<Texture2D>("plane");
            Vector2 screenCenter = new Vector2(GraphicsDevice.Viewport.Bounds.Width / 2, GraphicsDevice.Viewport.Bounds.Height / 2);
            Vector2 textureCenter = new Vector2(planeImg.Width / 2, planeImg.Height / 2);
            var velocity = new Vector2(0.0f, 0.0f);
            plane = new Plane(planeImg, 100, screenCenter, 1.0f, velocity);
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
                plane.Move(Direction.Up);
            }

            if(currentKeyboard.IsKeyDown(Keys.A))
            {
<<<<<<< HEAD
                plane.Rotate(Direction.Left);
=======
                plane.Move(Direction.Down);
>>>>>>> origin/Aaron-Projectile
            }

            if(currentKeyboard.IsKeyDown(Keys.D))
            {
<<<<<<< HEAD
                plane.Rotate(Direction.Right);

=======
                plane.Move(Direction.Left);
>>>>>>> origin/Aaron-Projectile
            }

            if(currentKeyboard.IsKeyDown(Keys.S))
            {
<<<<<<< HEAD
                //nothing? you must turn and thrust in opposite direction
=======
                plane.Move(Direction.Right);
>>>>>>> origin/Aaron-Projectile
            }

            if(currentKeyboard.IsKeyDown(Keys.Q))
            {
                plane.SwitchUpgrade(SwitchDirection.Left);
            }

            if(currentKeyboard.IsKeyDown(Keys.E))
            {
                plane.SwitchUpgrade(SwitchDirection.Right);
            }

            if(currentKeyboard.IsKeyDown(Keys.Space))
            {
                plane.Fire();
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

            if(LimitedUpdateTime == null || DateTime.Now.Ticks > (LimitedUpdateTime.AddMilliseconds(limitDelay)).Ticks)
            {

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);




            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
