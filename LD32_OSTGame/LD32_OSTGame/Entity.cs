using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace LD32_OSTGame
{
    public enum Direction
    {
        Up, Down, Left, Right
    }

    public enum SwitchDirection
    {
        Left, Right
    }

    //Base Entity becasue Matt and I wanted it
    public class Entity
    {
        public Rectangle Body { get; set; }

        protected Texture2D image { get; set; }
        protected Vector2 Position { get; set; }
        protected Vector2 Velocity { get; set; }
        protected float Rotation { get; set; }
        protected float Scale { get; set; }
        protected int Health { get; set; }

        public virtual void Collided(Entity collidedWith)
        {
            //make this do things
        }

        public virtual bool CheckCollsion(Entity checkCollide)
        {
            return Body.Intersects(checkCollide.Body);
        }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(GameTime gameTime, SpriteBatch batch) { }

        public virtual void LoadContent(ContentManager cm) { }

        public void Thrust(Direction dirToMove)
        {
            var thrustPower = new Vector2(0.0f, -0.05f);
            var newVector = RotateVector2(thrustPower, Rotation);

            Velocity += newVector;

        }

        public void Thrust(float power)
        {
            var thrustPower = new Vector2(0.0f, power);
            var newVector = RotateVector2(thrustPower, Rotation);

            Velocity += newVector;

        }

        public Vector2 RotateVector2(Vector2 vector, float n)
        {
            double rx = (vector.X * Math.Cos(n)) - (vector.Y * Math.Sin(n));
            double ry = (vector.X * Math.Sin(n)) + (vector.Y * Math.Cos(n));
            return new Vector2((float)rx, (float)ry);
        }

        // Rotate is in radians
        public void Rotate(Direction dirToRotate)
        {
            if (dirToRotate == Direction.Left)
            {
                Rotation -= 0.1f;
            }
            if (dirToRotate == Direction.Right)
            {
                Rotation += 0.1f;
            }

            Console.WriteLine(Rotation);
        }
         
    }
}
