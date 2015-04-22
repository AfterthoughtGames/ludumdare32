using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework.Audio;

namespace papercut
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
        public static int border = 350;

        RenderTarget2D bigScreen;

        public static List<Entity> Entites = new List<Entity>();
        public static List<Particle> Particles = new List<Particle>();
        private Texture2D planeImg;
        private Plane plane;
        public static Texture2D razorImg;
        public static Texture2D RazorEntImg;
        private Razor razor;

        private int resolutionOption = 0;

        private Texture2D Ball1;
        public static Texture2D ShardImg;
        public static Texture2D Particle1;
        private SpriteFont GUIFont;
        public static SoundEffect Pew;
        public static SoundEffect Hit;
        public static SoundEffect Rip;
        public static SoundEffect CatSound;

        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }
        public static int ActualScreenWidth { get; set; }
        public static int ActualScreenHeight { get; set; }
        public static bool DebugMode { get; set; }
        public static Texture2D DebugBoxRect { get; set; }
        public static int Score { get; set; }

        public static Texture2D Plane2Img { get; set; }
        public static Texture2D Plane3Img { get; set; }
        public static Texture2D Plane4Img { get; set; }

        public static Texture2D Kitten { get; set; }
        public static Texture2D KittenBullet { get; set; }

        private Texture2D SplashImg { get; set; }
        private Texture2D BgWood { get; set; }

        public static bool ActiveSplash = true;
        public static bool ActivePlay = false;
        public static bool ActiveInfo = false;

        public static int BallCount = 0;

        private bool SwitchRes = false;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            //graphics.PreferredBackBufferWidth = 1920;
            //graphics.PreferredBackBufferHeight = 1080;
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
            Window.Title = "Paper Cut - LD32";
            DebugBoxRect = new Texture2D(graphics.GraphicsDevice, 80, 30);
            Color[] data = new Color[80 * 30];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            DebugBoxRect.SetData(data);

            bigScreen = new RenderTarget2D(graphics.GraphicsDevice, graphics.PreferredBackBufferWidth + border, graphics.PreferredBackBufferHeight + border);

            GUIFont = Content.Load<SpriteFont>("GUIFont");

            Game1.ScreenWidth = bigScreen.Bounds.Width;
            Game1.ScreenHeight = bigScreen.Bounds.Height;
            ActualScreenHeight = graphics.GraphicsDevice.Viewport.Height;
            ActualScreenWidth = graphics.GraphicsDevice.Viewport.Width;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //load Balls
            Ball1 = Content.Load<Texture2D>("Ball1");
            ShardImg = Content.Load<Texture2D>("Shard");
            RazorEntImg = Content.Load<Texture2D>("Razor");

            Kitten = Content.Load<Texture2D>("Kitten");
            KittenBullet = Content.Load<Texture2D>("KittenBullet");

            Particle1 = Content.Load<Texture2D>("Particle1");

            planeImg = Content.Load<Texture2D>("plane");
            Plane2Img = Content.Load<Texture2D>("plane2");
            Plane3Img = Content.Load<Texture2D>("plane3");
            Plane4Img = Content.Load<Texture2D>("plane4");
            razorImg = Content.Load<Texture2D>("HappyRazorBladePickup");
            SplashImg = Content.Load<Texture2D>("splash768");
            BgWood = Content.Load<Texture2D>("bg1024");
            CatSound = Content.Load<SoundEffect>("cat");

            Vector2 textureCenter = new Vector2(planeImg.Width / 2, planeImg.Height / 2);

            var razorStart = new Vector2(500.0f, 500.0f);


            // Audio
            Pew = Content.Load<SoundEffect>("pew2");
            Hit = Content.Load<SoundEffect>("hit");
            Rip = Content.Load<SoundEffect>("rip");

            //populateEntities();
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

            #region ActivePlay
            if (ActivePlay == true)
            {
                if (BallCount == 0)
                {
                    populateEntities();
                }



                #region Keyboard
                KeyboardState currentKeyboard = Keyboard.GetState();

                if (currentKeyboard.IsKeyDown(Keys.W))
                {
                    plane.Thrust(Direction.Up);
                }

                if (currentKeyboard.IsKeyDown(Keys.A))
                {
                    plane.Rotate(Direction.Left);
                }

                if (currentKeyboard.IsKeyDown(Keys.D))
                {
                    plane.Rotate(Direction.Right);

                }

                if (currentKeyboard.IsKeyDown(Keys.S))
                {
                    //nothing? you must turn and thrust in opposite direction
                }

                if (currentKeyboard.IsKeyDown(Keys.Q))
                {
                    plane.SwitchUpgrade(SwitchDirection.Left);
                }

                if (currentKeyboard.IsKeyDown(Keys.E))
                {
                    plane.SwitchUpgrade(SwitchDirection.Right);
                }

                if (currentKeyboard.IsKeyDown(Keys.Space) && !PreviousKeyboard.IsKeyDown(Keys.Space))
                {
                    plane.Fire(gameTime);
                }

                // util keys
                if (currentKeyboard.IsKeyDown(Keys.F12) && !PreviousKeyboard.IsKeyDown(Keys.F12))
                {
                    if (Game1.DebugMode == true)
                    {
                        Game1.DebugMode = false;
                    }
                    else
                    {
                        Game1.DebugMode = true;
                    }
                }

                if (currentKeyboard.IsKeyDown(Keys.F11) && !PreviousKeyboard.IsKeyDown(Keys.F11))
                {
                    if (resolutionOption <= 3)
                    {
                        resolutionOption++;
                    }
                    else
                    {
                        resolutionOption = 0;
                    }

                    switch (resolutionOption)
                    {
                        case 1:
                            graphics.PreferredBackBufferWidth = 1280;
                            graphics.PreferredBackBufferHeight = 720;
                            graphics.ToggleFullScreen();
                            graphics.ApplyChanges();
                            //bigScreen = new RenderTarget2D(graphics.GraphicsDevice, graphics.PreferredBackBufferWidth + border, graphics.PreferredBackBufferHeight + border);
                            SwitchRes = true;
                            break;
                        case 2:
                            graphics.PreferredBackBufferWidth = 1920;
                            graphics.PreferredBackBufferHeight = 1080;
                            graphics.ApplyChanges();
                            //bigScreen = new RenderTarget2D(graphics.GraphicsDevice, graphics.PreferredBackBufferWidth + border, graphics.PreferredBackBufferHeight + border);
                            SwitchRes = true;
                            break;
                        case 3:
                            graphics.PreferredBackBufferWidth = 1024;
                            graphics.PreferredBackBufferHeight = 768;
                            graphics.ApplyChanges();
                            //bigScreen = new RenderTarget2D(graphics.GraphicsDevice, graphics.PreferredBackBufferWidth + border, graphics.PreferredBackBufferHeight + border);
                            SwitchRes = true;
                            break;
                        case 0:
                            graphics.PreferredBackBufferWidth = 1024;
                            graphics.PreferredBackBufferHeight = 768;
                            graphics.ToggleFullScreen();
                            graphics.ApplyChanges();
                            //bigScreen = new RenderTarget2D(graphics.GraphicsDevice, graphics.PreferredBackBufferWidth + border, graphics.PreferredBackBufferHeight + border);
                            SwitchRes = true;
                            break;
                        default:
                            break;
                    }
                }

                PreviousKeyboard = currentKeyboard;
                #endregion

                #region Gamepad
                GamePadState currentPad = GamePad.GetState(PlayerIndex.One);

                if (currentPad.DPad.Up == ButtonState.Pressed)
                {
                    plane.Thrust(Direction.Up);
                }

                if (currentPad.DPad.Down == ButtonState.Pressed)
                {
                    plane.Rotate(Direction.Down);
                }

                if (currentPad.DPad.Left == ButtonState.Pressed)
                {
                    plane.Rotate(Direction.Left);
                }

                if (currentPad.DPad.Right == ButtonState.Pressed)
                {
                    plane.Rotate(Direction.Right);
                }

                if (currentPad.Buttons.A == ButtonState.Pressed && PreviousGamePad.Buttons.A != ButtonState.Pressed)
                {
                    plane.Fire(gameTime);
                }

                if (currentPad.Buttons.X == ButtonState.Pressed)
                {
                    plane.SwitchUpgrade(SwitchDirection.Left);
                }

                if (currentPad.Buttons.Y == ButtonState.Pressed)
                {
                    plane.SwitchUpgrade(SwitchDirection.Right);
                }

                if (currentPad.ThumbSticks.Left.X < 0)
                {
                    plane.Rotate(Direction.Left);
                }

                if (currentPad.ThumbSticks.Left.X > 0)
                {
                    plane.Rotate(Direction.Right);
                }

                if (currentPad.ThumbSticks.Left.Y > 0)
                {
                    plane.Thrust(Direction.Up);
                }

                PreviousGamePad = currentPad;
                #endregion

                if (LimitedUpdateTime == null || DateTime.Now.Ticks > (LimitedUpdateTime.AddMilliseconds(limitDelay)).Ticks)
                {
                    // physiscs
                    // plane check
                    foreach (Entity currentEnt in Entites)
                    {
                        //update loop here too
                        currentEnt.Update(gameTime);

                        if (plane.CheckCollsion(currentEnt))
                        {
                            plane.Collided(currentEnt);
                            currentEnt.Collided(plane);
                        }
                    }

                    for (int outterIndex = 0; outterIndex < Entites.Count; outterIndex++)  //Entity outterEnt in Entites)
                    {
                        for (int innerCount = 0; innerCount < Entites.Count; innerCount++) //Entity innerEnt in Entites)
                        {
                            if (Entites[outterIndex] != Entites[innerCount])
                            {
                                if (Entites[outterIndex].CheckCollsion(Entites[innerCount]))
                                {
                                    Entites[outterIndex].Collided(Entites[innerCount]);
                                }
                            }
                        }
                    }
                }
                plane.Update(gameTime);

                foreach (Particle p in Particles)
                {
                    p.Update(gameTime);
                }

                for (int i = 0; i < Particles.Count; i++)
                {
                    if (Particles[i].health <= 0)
                    {
                        Particles.RemoveAt(i);
                    }
                }

                // cleanup entities 
                for (int count = 0; count < Entites.Count; count++)
                {
                    if (Entites[count].Health <= 0)
                    {
                        Entites.RemoveAt(count);
                    }
                }
            }
            #endregion

            #region ActiveSplash
            if (ActiveSplash == true)
            {
                KeyboardState currentKeyboard = Keyboard.GetState();
                GamePadState currentPad = GamePad.GetState(PlayerIndex.One);
                if (currentKeyboard.IsKeyDown(Keys.Space))
                {
                    ActiveSplash = false;
                    Entites.Clear();
                    BallCount = 0;
                    Particles.Clear();
                }

                if ((currentKeyboard.IsKeyDown(Keys.I) && !PreviousKeyboard.IsKeyDown(Keys.I)) || (currentPad.Buttons.B == ButtonState.Pressed && PreviousGamePad.Buttons.B == ButtonState.Released))
                {
                    if (ActiveInfo == false)
                    {
                        ActiveInfo = true;
                    }
                    else
                    {
                        ActiveInfo = false;
                    }
                }

                if (currentPad.Buttons.A == ButtonState.Pressed)
                {
                    ActiveSplash = false;
                }

                PreviousKeyboard = currentKeyboard;
                PreviousGamePad = currentPad;
            }
            #endregion

            if (ActiveSplash == false && ActivePlay == false)
            {
                SetupGame();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if(SwitchRes)
            {
                ScaleBuffer();
                SwitchRes = false;
            }

            if (ActivePlay == true)
            {
                GraphicsDevice.SetRenderTarget(bigScreen);
                GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin();
                //spriteBatch.Draw(BgWood, Vector2.Zero, Color.White);
                drawEntities(spriteBatch, gameTime);
                plane.Draw(spriteBatch, gameTime);
                drawParticles(spriteBatch, gameTime);
                //razor.Draw(gameTime, spriteBatch);
                spriteBatch.End();
                GraphicsDevice.SetRenderTarget(null);

                GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin();
                //spriteBatch.Draw(BgWood, Vector2.Zero, Color.White);

                //razor.Draw(gameTime, spriteBatch);
                plane.Draw(spriteBatch, gameTime);
                spriteBatch.Draw(bigScreen, new Vector2(-350, -350), null, null, null, 0, null, Color.White, SpriteEffects.None, 0);

                spriteBatch.DrawString(GUIFont, "Score: " + Game1.Score, new Vector2(900, 730), Color.Red);
                spriteBatch.DrawString(GUIFont, "Health: " + plane.Health, new Vector2(30, 730), Color.Red);
                spriteBatch.DrawString(GUIFont, "Power Up: " + plane.PowerUps[plane.PowerSlotIndex].GetType().ToString() + "   Ammo: " + plane.PowerUps[plane.PowerSlotIndex].AmmoCount.ToString(), new Vector2(200, 730), Color.Red);
                spriteBatch.End();
            }

            if (ActiveSplash == true)
            {
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Begin();
                if (ActiveInfo != true)
                {
                    spriteBatch.Draw(SplashImg, Vector2.Zero, Color.White);
                    spriteBatch.DrawString(GUIFont, "Press Space(A) to Start or I(B) for Information", new Vector2(105, 720), Color.Black);
                }
                else
                {
                    spriteBatch.DrawString(GUIFont, "This game was made with a 3 1/2  person crew in 16 hours during Ludum Dare 32. The goal for", new Vector2(10, 10), Color.Black);
                    spriteBatch.DrawString(GUIFont, "the group was to make a small and manageable game given the reduced time frame and relative", new Vector2(10, 30), Color.Black);
                    spriteBatch.DrawString(GUIFont, "inexperience with a game jam the crew had. What came out of this effort was a kitty lunching", new Vector2(10, 50), Color.Black);
                    spriteBatch.DrawString(GUIFont, "romp of an asteroid clone. Have fun and dont for get to follow us on twitter for more crazy", new Vector2(10, 70), Color.Black);
                    spriteBatch.DrawString(GUIFont, "adventures.", new Vector2(10, 90), Color.Black);
                    spriteBatch.DrawString(GUIFont, "I want to thank our family and friends for their support and patience during our time away", new Vector2(10, 130), Color.Black);
                    spriteBatch.DrawString(GUIFont, "from them. You guys rock.", new Vector2(10, 150), Color.Black);
                    spriteBatch.Draw(Kitten, new Vector2(450, 250), null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(GUIFont, "Code & Art -       Larry (Hipster Hockey Puck) Martian", new Vector2(10, 450), Color.Black);
                    spriteBatch.DrawString(GUIFont, "Code -             Matt (Lord of the Level) Johnson", new Vector2(10, 470), Color.Black);
                    spriteBatch.DrawString(GUIFont, "Code & Sound -     Aaron (Punching Enums) Van Prooyen", new Vector2(10, 490), Color.Black);
                    spriteBatch.DrawString(GUIFont, "Art & Porting -    Ben (Bald Spectator) Werden ", new Vector2(10, 510), Color.Black);
                    /*
                     * 

Code & Art – Larry “Hipster Hockey Puck” Martian
Code – Aaron “Punching Enums” Van Prooyen
Code –Matt “Lord of the Level” Johnson
Art & Porting – Ben “Bald Spectator” Werden 

                     * 
                     */
                }
                spriteBatch.End();
            }

            // HACK: remove this once we can write text to the screen
            //this.Window.Title = Score.ToString();

            base.Draw(gameTime);
        }

        private void drawEntities(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Entity ent in Entites)
            {
                ent.Draw(gameTime, spriteBatch);
            }
        }

        private void drawParticles(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Particle p in Particles)
            {
                p.Draw(gameTime, spriteBatch);
            }
        }

        private void populateEntities()
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            //make rocks
            for (int i = 0; i < 4; i++)
            {
                Ball ball = new Ball(Ball1, 20, new Vector2(rand.Next(0, bigScreen.Width - border), rand.Next(0, bigScreen.Height)), 1,
                    new Vector2((float)rand.Next(-200, 200), (float)rand.Next(-200, 200)), (float)rand.Next(-100, 100) / 100.0f);
                ball.Body = ball.ReturnNewBodyByScale(1);

                Entites.Add(ball);
                BallCount++;
            }

        }

        private void SetupGame()
        {
            var velocity = new Vector2(0.0f, 0.0f);
            Vector2 screenCenter = new Vector2(bigScreen.Width / 2, bigScreen.Height / 2);
            plane = new Plane(planeImg, 100, screenCenter, 1.0f, velocity, 0.0f);

            Score = 0;

            populateEntities();
            ActivePlay = true;
        }

        private void ScaleBuffer()
        {
            bigScreen = new RenderTarget2D(graphics.GraphicsDevice, graphics.PreferredBackBufferWidth + border, graphics.PreferredBackBufferHeight + border);
            Game1.ScreenWidth = bigScreen.Bounds.Width;
            Game1.ScreenHeight = bigScreen.Bounds.Height;
            ActualScreenHeight = graphics.GraphicsDevice.Viewport.Height;
            ActualScreenWidth = graphics.GraphicsDevice.Viewport.Width;
        }
    }
}
