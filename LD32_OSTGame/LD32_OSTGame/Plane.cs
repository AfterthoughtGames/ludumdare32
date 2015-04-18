﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    public class Plane : Entity
    {

        protected float FireRate { get; set; }
        protected Vector2 origin;

        public Plane(Texture2D image, int health, Vector2 position, float scale, Vector2 velocity, float rotation) : base()
        {
            this.image = image;
            this.Health = health;
            this.Position = position;
            this.Scale = scale;
            this.Velocity = velocity;
            this.Rotation = rotation;

            origin = new Vector2(image.Width / 2, image.Height / 2);
        }

        public void Thrust(Direction dirToMove)
        {
            Velocity += new Vector2(0.05f,0.0f);
        }

        public void Rotate(Direction dirToRotate)
        {
            if (dirToRotate == Direction.Left) Rotation -= 0.1f;
            if (dirToRotate == Direction.Right) Rotation += 0.1f;
        }

        public void Fire()
        {
            
        }

        public void SwitchUpgrade(SwitchDirection dir)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(image, Position, null, null, origin, Rotation, null,Color.White,SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            Position += Velocity;
        }


    }
}
