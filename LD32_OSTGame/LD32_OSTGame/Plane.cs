using Microsoft.Xna.Framework;
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
        public Matrix RotationMatrix = Matrix.Identity;

        public Plane(Texture2D image, int health, Vector2 position, float scale, Vector2 velocity, float rotation) : base()
        {
            this.image = image;
            this.Health = health;
            this.Position = position;
            this.Scale = scale;
            this.Velocity = velocity;
            this.Rotation = rotation;
        }

        public void Move(Direction dirToMove)
        {
            Velocity *= 1.2f;
        }

        public void Rotate(Direction dirToRotate)
        {
            if (dirToRotate == Direction.Left)
            {
                RotationMatrix = Matrix.CreateRotationY(Rotation);
            }
            else if (dirToRotate == Direction.Right)
            {
                
            }
        }

        public void Fire()
        {
            
        }

        public void SwitchUpgrade(SwitchDirection dir)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, new Vector2(400, 240), Color.White);
        }
    }
}
