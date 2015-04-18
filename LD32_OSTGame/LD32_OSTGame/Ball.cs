using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD32_OSTGame
{
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

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Draw(image, Position, null, null, origin, Rotation, null, Color.White, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime)
        {
            Rotation += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            //move me
            Position += Velocity * gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            if(Position.X < 0)
            {
                Position = new Vector2(1024 + Game1.border, Position.Y);
            }

            if (Position.X > 1024 + Game1.border)
            {
                Position = new Vector2(0, Position.Y);
            }

            if (Position.Y < 0)
            {
                Position = new Vector2(Position.X, 768 + Game1.border);
            }

            if (Position.Y > 768 + Game1.border)
            {
                Position = new Vector2(Position.X, 0);
            }

            base.Update(gameTime);
        }
    }
}
