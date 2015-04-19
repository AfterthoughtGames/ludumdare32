using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD32_OSTGame
{
    // all balls are made with this class just switch out the image and health
    public class Ball : Entity
    {
        Vector2 origin;
        float rotationSpeed;

        public Ball(Texture2D image, int health, Vector2 position, float scale, Vector2 velocity, float rotationSpeed)
            : base()
        {
            this.image = image;
            this.Health = health;
            this.Position = position;
            this.Scale = scale;
            this.Velocity = velocity;
            this.rotationSpeed = rotationSpeed;

            origin = new Vector2(image.Width / 2, image.Height / 2);
        }

        public override void Collided(Entity collidedWith)
        {
            Random rand = new Random();

            if (collidedWith.GetType() == typeof(ShardEnt))
            {
                Vector2 away = collidedWith.Position - Position;
                if (away.Length() < 140 * Scale)
                {
                    collidedWith.Health--;
                    this.Health--;
                    Game1.Hit.Play();


                    for (int i = 0; i < 5; i++)
                    {

                        Particle p = new Particle(Game1.Particle1, collidedWith.Position + new Vector2(rand.Next(-10, 10), rand.Next(-10, 10)), .5f * (float)rand.NextDouble(),
                            new Vector2(rand.Next(-5, 5), rand.Next(-5, 5)), (float)rand.NextDouble(), rand.Next(10, 20), new Color(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255), 1));
                        Game1.Particles.Add(p);
                    }

                    if (this.Health == 0)
                    {
                        Game1.Rip.Play();

                        Game1.Score++;

                        //should probably do some sort of health check???
                        Game1.BallCount--;

                        if (this.Scale > 0.125)
                        {

                            //random powerup placment
                            Random rndPower = new Random();

                            int rndNum = rndPower.Next(100);

                            if(rndNum < 20)
                            {
                                Game1.Entites.Add(new Razor(Game1.razorImg, this.Position, 1, 0));
                            }

                            Ball ball1 = new Ball(image, 3, new Vector2(Position.X, Position.Y), (Scale / 2),
                            new Vector2((float)rand.Next(-200, 200), (float)rand.Next(-200, 200)), (float)rand.Next(-100, 100) / 100.0f);

                            ball1.Body = this.ReturnNewBodyByScale(ball1.Scale); //new Rectangle((int)Position.X, (int)Position.Y, (int)(this.image.Width * ball1.Scale), (int)(this.image.Height * ball1.Scale));

                            Game1.Entites.Add(ball1);

                            Ball ball2 = new Ball(image, 3, new Vector2(Position.X, Position.Y), (Scale / 2),
                            new Vector2((float)rand.Next(-200, 200), (float)rand.Next(-200, 200)), (float)rand.Next(-100, 100) / 100.0f);

                            ball2.Body = this.ReturnNewBodyByScale(ball2.Scale); //new Rectangle((int)Position.X, (int)Position.Y, (int)(this.image.Width * ball2.Scale), (int)(this.image.Height * ball2.Scale));

                            Game1.Entites.Add(ball2);



                            Game1.BallCount++;
                            Game1.BallCount++;
                        }
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Draw(image, Position, null, null, origin, Rotation, new Vector2(this.Scale), Color.White, SpriteEffects.None, 0);

            base.Draw(gameTime, batch);
        }

        public override void Update(GameTime gameTime)
        {
            Rotation += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            //move me
            Position += Velocity * gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            wrap();

            this.Body = this.ReturnNewBodyByScale(this.Scale);

            base.Update(gameTime);
        }
    }
}
