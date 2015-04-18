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
        public static int border = 360;

        RenderTarget2D bigScreen;

        public static List<Entity> Entites = new List<Entity>();        
        private Texture2D planeImg;
        private Plane plane;

        private Texture2D Ball1;
        public static Texture2D ShardImg;

        public static int ScreenWidth { get; set; }
        public static int ScrrenHeight { get; set; }
        public static bool DebugMode { get; set; }
        public static Texture2D DebugBoxRect { get; set; }
        
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
            
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
            
            
            DebugBoxRect = new Texture2D(graphics.GraphicsDevice, 80, 30);
            Color[] data = new Color[80 * 30];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            DebugBoxRect.SetData(data);

            bigScreen = new RenderTarget2D(graphics.GraphicsDevice, graphics.PreferredBackBufferWidth + border, graphics.PreferredBackBufferHeight + border);

            Game1.ScreenWidth = bigScreen.Bounds.Width;
            Game1.ScrrenHeight = bigScreen.Bounds.Height;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //load Balls
            Ball1 = Content.Load<Texture2D>("Ball1");
            ShardImg = Content.Load<Texture2D>("Shard");

            planeImg = Content.Load<Texture2D>("plane");
            Vector2 screenCenter = new Vector2(bigScreen.Width / 2, bigScreen.Height / 2);
            Vector2 textureCenter = new Vector2(planeImg.Width / 2, planeImg.Height / 2);
            var velocity = new Vector2(0.0f, 0.0f);
            plane = new Plane(planeImg, 100, screenCenter, 1.0f, velocity, 0.0f);

            populateEntities();
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
                plane.Thrust(Direction.Up);
            }

            if(currentKeyboard.IsKeyDown(Keys.A))
            {
                plane.Rotate(Direction.Left);
            }

            if(currentKeyboard.IsKeyDown(Keys.D))
            {
                plane.Rotate(Direction.Right);

            }

            if(currentKeyboard.IsKeyDown(Keys.S))
            {
                //nothing? you must turn and thrust in opposite direction
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

            // util keys
            if(currentKeyboard.IsKeyDown(Keys.F12))
            {
                if(Game1.DebugMode == true)
                {
                    Game1.DebugMode = false;
                }
                else
                {
                    Game1.DebugMode = true;
                }
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
                // physiscs
                // plane check
                foreach(Entity currentEnt in Entites)
                {
                    //update loop here too
                    currentEnt.Update(gameTime);

                    if(plane.CheckCollsion(currentEnt))
                    {
                        plane.Collided(currentEnt);
                        currentEnt.Collided(plane);
                    }
                }

                foreach(Entity outterEnt in Entites)
                {
                    foreach(Entity innerEnt in Entites)
                    {
                        if(outterEnt != innerEnt)
                        {
                            if(outterEnt.CheckCollsion(innerEnt))
                            {
                                outterEnt.Collided(innerEnt);
                            }
                        }
                    }
                }
            }
            plane.Update(gameTime);

            // cleanup entities 
            for (int count = 0; count < Entites.Count; count++)
            {
                if(Entites[count].Health <= 0)
                {
                     Entites.RemoveAt(count);
                }
            }

                base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(bigScreen);

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
                plane.Draw(spriteBatch, gameTime);
                drawEntities(spriteBatch, gameTime);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
                plane.Draw(spriteBatch, gameTime);
                spriteBatch.Draw(bigScreen, new Vector2(-350,-350), null, null, null, 0, null, Color.White, SpriteEffects.None, 0);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void drawEntities(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach(Entity ent in Entites)
            {
                ent.Draw(gameTime, spriteBatch);
            }
        }

        private void populateEntities()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            
            //make rocks
            Ball ball = new Ball(Ball1, 100, new Vector2(rand.Next(0, bigScreen.Width - border), rand.Next(0, bigScreen.Height)), 1,
                new Vector2((float)rand.Next(-200, 200), (float)rand.Next(-200, 200)), (float)rand.Next(-100, 100) / 100.0f);

            Entites.Add(ball);
        }
    }
}
