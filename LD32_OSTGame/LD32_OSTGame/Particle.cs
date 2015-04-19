using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD32_OSTGame
{
    public class Particle
    {
        protected Texture2D image { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        protected float Rotation { get; set; }
        public float Scale { get; set; }
        protected float rotationSpeed { get; set; }
        protected Vector2 origin;
        public int health { get; set; }
        protected float maxHealth { get; set; }
        private Color color;

        public Particle(Texture2D image, Vector2 position, float scale, Vector2 velocity, float rotationSpeed, int health, Color color)
        {
            this.image = image;
            Position = position;
            Scale = scale;
            Velocity = velocity;
            this.rotationSpeed = rotationSpeed;
            origin = new Vector2(image.Width / 2, image.Height / 2);
            this.health = health;
            maxHealth = health;
            this.color = color;
        }

        public virtual void Update(GameTime gameTime) 
        {
            health--;
            Rotation += rotationSpeed;
            Position += Velocity;
              Scale = .5f * (float)(health / maxHealth);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Draw(image, Position, null, null, origin, Rotation, new Vector2(Scale,Scale), color, SpriteEffects.None, 0);
        }
    }
}
