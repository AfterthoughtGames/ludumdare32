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

        public Plane(Texture2D image, int health, Vector2 position, float scale, Vector2 velocity) : base()
        {
            this.image = image;
            this.Health = health;
            this.Position = position;
            this.Scale = scale;
            this.Velocity = velocity;
        }

        public void Move(Direction dirToMove)
        {
            
        }

        public void Rotate(Direction dirToMove)
        {
            
        }

        public void Fire()
        {
            
        }

        public void SwitchUpgrade(SwitchDirection dir)
        {
            
        }
    }
}
