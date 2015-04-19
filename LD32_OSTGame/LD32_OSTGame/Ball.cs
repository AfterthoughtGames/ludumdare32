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

        public Ball(Texture2D image, int health, Vector2 position, float scale, Vector2 velocity, float rotationSpeed) : base()
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

            if(collidedWith.GetType() == typeof(ShardEnt))
            {
                this.Health--;

                //should probably do some sort of health check???
                Game1.BallCount--;

                 Game1.Entites.Add(new Ball(image, 100, new Vector2(Position.X, Position.Y), (Scale / 2),
                new Vector2((float)rand.Next(-200, 200), (float)rand.Next(-200, 200)), (float)rand.Next(-100, 100) / 100.0f));

                 Game1.BallCount++;
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

            this.Body = this.ReturnNewBody();

            base.Update(gameTime);
        }
    }
}
